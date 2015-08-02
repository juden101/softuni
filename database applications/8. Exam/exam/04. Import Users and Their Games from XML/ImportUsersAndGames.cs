namespace ImportUsersGames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using DiabloMappings;

    class ImportUsersAndGames
    {
        static void Main()
        {
            var diabloContext = new DiabloEntities();
            Queue<string> output = new Queue<string>();

            var xmlDocument = XDocument.Load("../../users-and-games.xml");
            var userNodes = xmlDocument.XPathSelectElements("/users/user");
            List<UserDTO> users = new List<UserDTO>();
            var allUsers = diabloContext.Users.ToList();
            var allCharacters = diabloContext.Characters.ToList();
            var allUsersGames = diabloContext.UsersGames.ToList();
            var allGames = diabloContext.Games.ToList();

            foreach (var userNode in userNodes)
            {
                UserDTO currentUser = null;

                string firstName = null;
                string lastName = null;
                string email = null;
                string username = userNode.Attribute("username").Value;
                bool isDeleted = userNode.Attribute("is-deleted").Value == "1";
                string ipAddress = userNode.Attribute("ip-address").Value;
                DateTime registrationDate = Convert.ToDateTime(userNode.Attribute("registration-date").Value);

                if (userNode.Attribute("first-name") != null)
                {
                    firstName = userNode.Attribute("first-name").Value;
                }

                if (userNode.Attribute("last-name") != null)
                {
                    lastName = userNode.Attribute("last-name").Value;
                }

                if (userNode.Attribute("email") != null)
                {
                    email = userNode.Attribute("email").Value;
                }
                
                currentUser = new UserDTO()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Username = username,
                    Email = email,
                    IsDeleted = isDeleted,
                    IpAddress = ipAddress,
                    RegistrationDate = registrationDate
                };

                var gameNodes = userNode.XPathSelectElements("games/game");
                foreach (var gameNode in gameNodes)
                {
                    XElement characterNode = gameNode.XPathSelectElement("character");

                    string gameName = gameNode.XPathSelectElement("game-name").Value;
                    DateTime joinedOn = Convert.ToDateTime(gameNode.XPathSelectElement("joined-on").Value);
                    string characterName = characterNode.Attribute("name").Value;
                    decimal characterCash = Decimal.Parse(characterNode.Attribute("cash").Value);
                    int characterLevel = int.Parse(characterNode.Attribute("level").Value);

                    CharacterDTO currentCharacter = new CharacterDTO()
                    {
                        Name = characterName,
                        Cash = characterCash,
                        Level = characterLevel
                    };

                    GameDTO currentGame = new GameDTO()
                    {
                        Name = gameName,
                        JoinedOn = joinedOn,
                        Character = currentCharacter
                    };

                    currentUser.Games.Add(currentGame);
                }
                
                users.Add(currentUser);
            }

            foreach (var user in users)
            {
                var currentUser = allUsers.Where(u => u.Username == user.Username).FirstOrDefault();

                if (currentUser == null)
                {
                    currentUser = new User()
                    {
                        Username = user.Username,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        RegistrationDate = user.RegistrationDate,
                        IsDeleted = user.IsDeleted,
                        IpAddress = user.IpAddress,
                        UsersGames = new HashSet<UsersGame>()
                    };

                    diabloContext.Users.Add(currentUser);
                    output.Enqueue(string.Format("Successfully added user {0}", currentUser.Username));

                    foreach (var game in user.Games)
                    {
                        UsersGame currentGame = new UsersGame()
                        {
                            GameId = allGames.Where(g => g.Name == game.Name).Select(g => g.Id).FirstOrDefault(),
                            Level = game.Character.Level,
                            Cash = game.Character.Cash,
                            Character = allCharacters.Where(c => c.Name == game.Character.Name).FirstOrDefault(),
                            JoinedOn = game.JoinedOn
                        };

                        currentUser.UsersGames.Add(currentGame);
                        output.Enqueue(string.Format("User {0} successfully added to game {1}", user.Username, game.Name));
                    }
                }
                else
                {
                    output.Enqueue(string.Format("User {0} already exists", currentUser.Username));
                }

                diabloContext.SaveChanges();
            }

            while (output.Count > 0)
            {
                Console.WriteLine(output.Dequeue());
            }
        }
    }
}