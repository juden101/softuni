using System;
using System.Linq;
using System.Collections.Generic;

public class GraphConnectedComponents
{
    static new List<int>[] graph;

    static bool[] visited;

    static void DFS(int node)
    {
        if (!visited[node])
        {
            visited[node] = true;

            foreach (int childNode in graph[node])
            {
                DFS(childNode);
            }

            Console.Write("{0} ", node);
        }
    }

    static void FindGraphConnectedComponents()
    {
        visited = new bool[graph.Length];

        for (int startNode = 0; startNode < graph.Length; startNode++)
        {
            if (!visited[startNode])
            {
                Console.Write("Connected component: ");
                DFS(startNode);
                Console.WriteLine();
            }
        }
    }

    static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        List<int>[] graph = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }

        return graph;
    }

    public static void Main()
    {
        graph = ReadGraph();
        FindGraphConnectedComponents();
    }
}