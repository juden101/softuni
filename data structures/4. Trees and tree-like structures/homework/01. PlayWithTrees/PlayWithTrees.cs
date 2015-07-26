namespace homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayWithTrees
    {
        public static Dictionary<int, Tree<int>> nodeByValue;

        public static void Main()
        {
            nodeByValue = new Dictionary<int, Tree<int>>();
            int nodesCount = int.Parse(Console.ReadLine());

            for (int i = 1; i < nodesCount; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(edge[0]);
                int childValue = int.Parse(edge[1]);

                Tree<int> parentNode = GetTreeNodeByValue(parentValue);
                Tree<int> childNode = GetTreeNodeByValue(childValue);

                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            // • The root node
            var rootNode = FindRootNode();

            Console.WriteLine("Root: {0}", rootNode.Value);

            // • All leaf nodes (in increasing order)
            var leafNodes = FindLeafNodes();

            Console.WriteLine("Lead nodes: {0}",
                string.Join(", ", leafNodes
                    .OrderBy(n => n.Value)
                    .Select(n => n.Value)));

            // • All middle nodes (in increasing order)
            var middleNodes = FindMiddleNodes();

            Console.WriteLine("Middle nodes: {0}",
                string.Join(", ", middleNodes
                    .OrderBy(n => n.Value)
                    .Select(n => n.Value)));

            // •* The longest path in the tree (the leftmost if several paths have the same longest length)
            var longestPath = FindLongestPath(rootNode).ToArray().Reverse();

            Console.WriteLine("Longest path: {0} (length = {1})",
                string.Join(" -> ", longestPath.Select(n => n.Value)),
                longestPath.Count());
        }

        public static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }

        public static Tree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(node => node.Parent == null);

            return rootNode;
        }

        public static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var middleNodes = nodeByValue.Values
                .Where(node =>
                    node.Children.Count > 0 &&
                    node.Parent != null)
                .ToList();

            return middleNodes;
        }

        public static IEnumerable<Tree<int>> FindLeafNodes()
        {
            var leafNodes = nodeByValue.Values
                .Where(node =>
                    node.Children.Count == 0 &&
                    node.Parent != null)
                .ToList();

            return leafNodes;
        }

        public static ICollection<Tree<int>> FindLongestPath(Tree<int> treeNode)
        {
            ICollection<Tree<int>> longestPath = new List<Tree<int>>();

            foreach (var childNode in treeNode.Children)
            {
                var currentPath = FindLongestPath(childNode);

                if (currentPath.Count > longestPath.Count)
                {
                    longestPath = currentPath;
                }
            }

            longestPath.Add(treeNode);

            return longestPath;
        }
    }
}
