using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Scoreboard
{
    public class ScoreboardMain
    {
        static void Main()
        {
            Scoreboard scoreboard = new Scoreboard();
            string commandLine = Console.ReadLine();

            while (commandLine != "End")
            {
                string output = scoreboard.ProcessCommand(commandLine);

                if (output != "")
                {
                    Console.WriteLine(output);
                }

                commandLine = Console.ReadLine();
            }
        }
    }

    public class Scoreboard
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();
        private Dictionary<string, Game> games = new Dictionary<string, Game>();
        private Dictionary<string, OrderedMultiDictionary<long, Score>> scores = new Dictionary<string, OrderedMultiDictionary<long, Score>>();
        private Trie<bool> prefixes = new Trie<bool>();

        public string ProcessCommand(string commandLine)
        {
            string[] tokens = commandLine.Split(' ');
            string command = tokens[0];

            switch (command)
            {
                case "RegisterUser":
                    string username = tokens[1];
                    string password = tokens[2];

                    User user = new User()
                    {
                        Username = username,
                        Password = password
                    };

                    if (this.users.ContainsKey(username))
                    {
                        return "Duplicated user";
                    }

                    this.users.Add(username, user);

                    return "User registered";
                case "RegisterGame":
                    string gameName = tokens[1];
                    string gamePassword = tokens[2];

                    if (this.games.ContainsKey(gameName))
                    {
                        return "Duplicated game";
                    }

                    Game game = new Game()
                    {
                        GameName = gameName,
                        Password = gamePassword
                    };

                    this.games.Add(gameName, game);
                    this.prefixes.Add(new TrieEntry<bool>(gameName, true));

                    return "Game registered";
                case "AddScore":
                    string scoreUsername = tokens[1];
                    string scoreUsernamePassword = tokens[2];


                    User scoreUser;
                    this.users.TryGetValue(scoreUsername, out scoreUser);
                    if (scoreUser == null || scoreUser.Password != scoreUsernamePassword)
                    {
                        return "Cannot add score";
                    }

                    string scoreGameName = tokens[3];
                    string scoreGamePassword = tokens[4];

                    Game scoreGame;
                    this.games.TryGetValue(scoreGameName, out scoreGame);

                    if (scoreGame == null || scoreGame.Password != scoreGamePassword)
                    {
                        return "Cannot add score";
                    }

                    long scorePoints = long.Parse(tokens[5]);

                    Score score = new Score()
                    {
                        User = scoreUser,
                        Game = scoreGame,
                        Points = scorePoints
                    };

                    if (!this.scores.ContainsKey(scoreGameName))
                    {
                        this.scores.Add(scoreGameName, new OrderedMultiDictionary<long, Score>(true, (x, y) => y.CompareTo(x)));
                    }

                    this.scores[scoreGameName].Add(scorePoints, score);

                    return "Score added";
                case "ShowScoreboard":
                    string showGameName = tokens[1];

                    if (this.games.ContainsKey(showGameName))
                    {
                        if (this.scores.ContainsKey(showGameName))
                        {
                            var scoreGameMatches = this.scores[showGameName].Values.Take(10).ToList();

                            if (scoreGameMatches.Count() > 0)
                            {
                                int i = 0;
                                StringBuilder output = new StringBuilder();

                                foreach (var ss in scoreGameMatches)
                                {
                                    i++;
                                    output.AppendLine("#" + i + " " + ss.User.Username + " " + ss.Points);
                                }

                                return output.ToString().Trim();
                            }
                        }

                        return "No score";
                    }

                    return "Game not found";
                case "ListGamesByPrefix":
                    string namePrefix = tokens[1];
                    var resultTrie = this.prefixes.GetByPrefix(namePrefix).Select(g => g.Key).Take(30);
                    var resultTrie2 = this.prefixes.GetByPrefix(namePrefix).Select(g => g.Key).Skip(100).Take(30);
                    // order by bottleneck

                    if (resultTrie.Any())
                    {
                        return string.Join(", ", resultTrie.Union(resultTrie2).OrderBy(rr => rr).Take(10));
                    }

                    return "No matches";
                case "DeleteGame":
                    string deleteGameName = tokens[1];
                    string deleteGamePassword = tokens[2];
                    
                    if (this.games.ContainsKey(deleteGameName))
                    {
                        Game deleteGame = this.games[deleteGameName];

                        if (deleteGame.Password != deleteGamePassword)
                        {
                            return "Cannot delete game";
                        }

                        this.scores.Remove(deleteGameName);
                        this.games.Remove(deleteGameName);
                        this.prefixes.Remove(deleteGame.GameName);

                        return "Game deleted";
                    }

                    return "Cannot delete game";
                default:
                    return "";
            }
        }
    }

    public class User : IEqualityComparer<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        
        public bool Equals(User x, User y)
        {
            if (x == y)
            {
                return true;
            }

            return String.Compare(x.Username, y.Username, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public int GetHashCode(User u)
        {
            return u.GetHashCode();
        }
    }

    public class Game
    {
        public string GameName { get; set; }
        public string Password { get; set; }
    }

    public class Score : IComparable<Score>
    {
        public User User { get; set; }
        public Game Game { get; set; }
        public long Points { get; set; }

        public int CompareTo(Score other)
        {
            if (this == other)
            {
                return 0;
            }

            var result = other.Points.CompareTo(this.Points);

            if (result == 0)
            {
                result = string.Compare(this.User.Username, other.User.Username, StringComparison.OrdinalIgnoreCase);
            }

            return result;
        }
    }

    /// <summary>
    /// Implementation of "trie" data structure.
    /// </summary>
    /// <typeparam name="TValue">The type of values in the trie.</typeparam>
    public class Trie<TValue> : IDictionary<string, TValue>
    {
        private readonly TrieNode root;

        private int count;

        /// <summary>
        /// Initializes a new instance of the <see cref="Trie{TValue}"/>.
        /// </summary>
        /// <param name="comparer">Comparer.</param>
        public Trie(IEqualityComparer<char> comparer)
        {
            root = new TrieNode(char.MinValue, comparer);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Trie{TValue}"/>.
        /// </summary>
        public Trie()
            : this(EqualityComparer<char>.Default)
        {
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        public int Count
        {
            get
            {
                return count;
            }
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the keys of the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.ICollection`1"/> containing the keys of the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </returns>
        public ICollection<string> Keys
        {
            get
            {
                return GetAllNodes().Select(n => n.Key).ToArray();
            }
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the values in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.Generic.ICollection`1"/> containing the values in the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </returns>
        public ICollection<TValue> Values
        {
            get
            {
                return GetAllNodes().Select(n => n.Value).ToArray();
            }
        }

        bool ICollection<KeyValuePair<string, TValue>>.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the element with the specified key.
        /// </summary>
        /// <returns>
        /// The element with the specified key.
        /// </returns>
        /// <param name="key">The key of the element to get or set.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
        /// <exception cref="T:System.Collections.Generic.KeyNotFoundException">The property is retrieved and <paramref name="key"/> is not found.</exception>
        public TValue this[string key]
        {
            get
            {
                TValue value;

                if (!TryGetValue(key, out value))
                {
                    throw new KeyNotFoundException("The given charKey was not present in the trie.");
                }

                return value;
            }

            set
            {
                TrieNode node;

                if (TryGetNode(key, out node))
                {
                    SetTerminalNode(node, value);
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        /// <summary>
        /// Adds an element with the provided charKey and value to the <see cref="Trie{TValue}"/>.
        /// </summary>
        /// <param name="key">The object to use as the charKey of the element to add.</param>
        /// <param name="value">The object to use as the value of the element to add.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
        /// <exception cref="T:System.ArgumentException">An element with the same charKey already exists in the <see cref="Trie{TValue}"/>.</exception>
        public void Add(string key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            var node = root;

            foreach (var c in key)
            {
                node = node.Add(c);
            }

            if (node.IsTerminal)
            {
                throw new ArgumentException(string.Format("An element with the same charKey already exists: '{0}'", key), "key");
            }

            SetTerminalNode(node, value);

            count++;
        }

        /// <summary>
        /// Adds an item to the <see cref="Trie{TValue}"/>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="Trie{TValue}"/>.</param>
        /// <exception cref="T:System.ArgumentException">An element with the same charKey already exists in the <see cref="Trie{TValue}"/>.</exception>
        public void Add(TrieEntry<TValue> item)
        {
            Add(item.Key, item.Value);
        }

        /// <summary>
        /// Adds the elements of the specified collection to the <see cref="Trie{TValue}"/>.
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the <see cref="Trie{TValue}"/>. The items should have unique keys.</param>
        /// <exception cref="T:System.ArgumentException">An element with the same charKey already exists in the <see cref="Trie{TValue}"/>.</exception>
        public void AddRange(IEnumerable<TrieEntry<TValue>> collection)
        {
            foreach (var item in collection)
            {
                Add(item.Key, item.Value);
            }
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only. </exception>
        public void Clear()
        {
            root.Clear();
            count = 0;
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the specified charKey.
        /// </summary>
        /// <returns>
        /// true if the <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the charKey; otherwise, false.
        /// </returns>
        /// <param name="key">The charKey to locate in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
        public bool ContainsKey(string key)
        {
            TValue value;

            return TryGetValue(key, out value);
        }

        /// <summary>
        /// Gets items by key prefix.
        /// </summary>
        /// <param name="prefix">Key prefix.</param>
        /// <returns>Collection of <see cref="TrieEntry{TValue}"/> items which have key with specified key.</returns>
        public IEnumerable<TrieEntry<TValue>> GetByPrefix(string prefix)
        {
            var node = root;

            foreach (var item in prefix)
            {
                if (!node.TryGetNode(item, out node))
                {
                    return Enumerable.Empty<TrieEntry<TValue>>();
                }
            }

            return node.GetByPrefix();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<KeyValuePair<string, TValue>> GetEnumerator()
        {
            return GetAllNodes().Select(n => new KeyValuePair<string, TValue>(n.Key, n.Value)).GetEnumerator();
        }

        /// <summary>
        /// Removes the element with the specified charKey from the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </summary>
        /// <returns>
        /// true if the element is successfully removed; otherwise, false.  This method also returns false if <paramref name="key"/> was not found in the original <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </returns>
        /// <param name="key">The charKey of the element to remove.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IDictionary`2"/> is read-only.</exception>
        public bool Remove(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            TrieNode node;

            if (!TryGetNode(key, out node))
            {
                return false;
            }

            if (!node.IsTerminal)
            {
                return false;
            }

            RemoveNode(node);

            return true;
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <returns>
        /// true if the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the specified key; otherwise, false.
        /// </returns>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
        public bool TryGetValue(string key, out TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            TrieNode node;
            value = default(TValue);

            if (!TryGetNode(key, out node))
            {
                return false;
            }

            if (!node.IsTerminal)
            {
                return false;
            }

            value = node.Value;

            return true;
        }

        void ICollection<KeyValuePair<string, TValue>>.Add(KeyValuePair<string, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        bool ICollection<KeyValuePair<string, TValue>>.Contains(KeyValuePair<string, TValue> item)
        {
            TrieNode node;

            if (!TryGetNode(item.Key, out node))
            {
                return false;
            }

            return node.IsTerminal && EqualityComparer<TValue>.Default.Equals(node.Value, item.Value);
        }

        void ICollection<KeyValuePair<string, TValue>>.CopyTo(KeyValuePair<string, TValue>[] array, int arrayIndex)
        {
            Array.Copy(GetAllNodes().Select(n => new KeyValuePair<string, TValue>(n.Key, n.Value)).ToArray(), 0, array, arrayIndex, Count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        bool ICollection<KeyValuePair<string, TValue>>.Remove(KeyValuePair<string, TValue> item)
        {
            TrieNode node;

            if (!TryGetNode(item.Key, out node))
            {
                return false;
            }

            if (!node.IsTerminal)
            {
                return false;
            }

            if (!EqualityComparer<TValue>.Default.Equals(node.Value, item.Value))
            {
                return false;
            }

            RemoveNode(node);

            return true;
        }

        private static void SetTerminalNode(TrieNode node, TValue value)
        {
            node.IsTerminal = true;
            node.Value = value;
        }

        private IEnumerable<TrieNode> GetAllNodes()
        {
            return root.GetAllNodes();
        }

        private void RemoveNode(TrieNode node)
        {
            node.Remove();
            count--;
        }

        private bool TryGetNode(string key, out TrieNode node)
        {
            node = root;

            foreach (var c in key)
            {
                if (!node.TryGetNode(c, out node))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// <see cref="Trie{TValue}"/>'s node.
        /// </summary>
        private sealed class TrieNode
        {
            private readonly Dictionary<char, TrieNode> children;

            private readonly IEqualityComparer<char> comparer;

            private readonly char keyChar;

            internal TrieNode(char keyChar, IEqualityComparer<char> comparer)
            {
                this.keyChar = keyChar;
                this.comparer = comparer;
                children = new Dictionary<char, TrieNode>(comparer);
            }

            internal bool IsTerminal { get; set; }

            internal string Key
            {
                get
                {
                    ////var result = new StringBuilder().Append(keyChar);

                    ////TrieNode node = this;

                    ////while ((node = node.Parent).Parent != null)
                    ////{
                    ////    result.Insert(0, node.keyChar);
                    ////}

                    ////return result.ToString();

                    var stack = new Stack<char>();
                    stack.Push(keyChar);

                    TrieNode node = this;

                    while ((node = node.Parent).Parent != null)
                    {
                        stack.Push(node.keyChar);
                    }

                    return new string(stack.ToArray());
                }
            }

            internal TValue Value { get; set; }

            private TrieNode Parent { get; set; }

            internal TrieNode Add(char key)
            {
                TrieNode childNode;

                if (!children.TryGetValue(key, out childNode))
                {
                    childNode = new TrieNode(key, comparer)
                    {
                        Parent = this
                    };

                    children.Add(key, childNode);
                }

                return childNode;
            }

            internal void Clear()
            {
                children.Clear();
            }

            internal IEnumerable<TrieNode> GetAllNodes()
            {
                foreach (var child in children)
                {
                    if (child.Value.IsTerminal)
                    {
                        yield return child.Value;
                    }

                    foreach (var item in child.Value.GetAllNodes())
                    {
                        if (item.IsTerminal)
                        {
                            yield return item;
                        }
                    }
                }
            }

            internal IEnumerable<TrieEntry<TValue>> GetByPrefix()
            {
                if (IsTerminal)
                {
                    yield return new TrieEntry<TValue>(Key, Value);
                }

                foreach (var item in children)
                {
                    foreach (var element in item.Value.GetByPrefix())
                    {
                        yield return element;
                    }
                }
            }

            internal void Remove()
            {
                IsTerminal = false;

                if (children.Count == 0 && Parent != null)
                {
                    Parent.children.Remove(keyChar);

                    if (!Parent.IsTerminal)
                    {
                        Parent.Remove();
                    }
                }
            }

            internal bool TryGetNode(char key, out TrieNode node)
            {
                return children.TryGetValue(key, out node);
            }
        }
    }

    /// <summary>
    /// Defines a key/value pair that can be set or retrieved from <see cref="Trie{TValue}"/>.
    /// </summary>
    public struct TrieEntry<TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrieEntry{TValue}"/> structure with the specified key and value.
        /// </summary>
        /// <param name="key">The <see cref="string"/> object defined in each key/value pair.</param>
        /// <param name="value">The definition associated with key.</param>
        public TrieEntry(string key, TValue value)
            : this()
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Gets the key in the key/value pair.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Gets the value in the key/value pair.
        /// </summary>
        public TValue Value { get; private set; }

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> containing a fully qualified type name.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return string.Format("[{0}, {1}]", Key, Value);
        }
    }
}