namespace homework
{
    using System;
    using System.Collections.Generic;

    public class RoundDance
    {
        private static new Dictionary<int, List<int>> graph;
        private static new List<int> visited;
        private static int currentLength;
        private static int maxLength;

        static void Main()
        {
            int numberOfFriendships = int.Parse(Console.ReadLine());
            int leadNode = int.Parse(Console.ReadLine());

            graph = ReadGraph(numberOfFriendships);
            visited = new List<int>();
            currentLength = 0;
            maxLength = 0;

            DFS(leadNode);

            Console.WriteLine(maxLength);
        }

        private static void DFS(int node)
        {
            if (!visited.Contains(node))
            {
                visited.Add(node);
                currentLength++;

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                }

                foreach (var childNode in graph[node])
                {
                    DFS(childNode);
                }

                currentLength = 1;
            }
        }

        private static Dictionary<int, List<int>> ReadGraph(int numberOfFriendships)
        {

            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < numberOfFriendships; i++)
            {
                string[] currentFriendship = Console.ReadLine().Split(' ');
                int first = int.Parse(currentFriendship[0]);
                int second = int.Parse(currentFriendship[1]);
                
                if(!graph.ContainsKey(first))
                {
                    graph.Add(first, new List<int>());
                }

                if (!graph.ContainsKey(second))
                {
                    graph.Add(second, new List<int>());
                }

                graph[first].Add(second);
                graph[second].Add(first);
            }

            return graph;
        }
    }
}