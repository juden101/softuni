namespace homework
{
    using System;
    using System.Linq;

    class FindTheRoot
    {
        public static void Main()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            int numberOfEdges = int.Parse(Console.ReadLine());
            bool[] hasParent = new bool[numberOfNodes];

            for (int i = 0; i < numberOfEdges; i++)
            {
                string currentLine = Console.ReadLine();
                string[] input = currentLine.Split(' ');
                int child = int.Parse(input[1]);

                hasParent[child] = true;
            }

            var parentNodes = hasParent
                .Select((value, key) => new { value, key })
                .Where(p => p.value == false)
                .Select(p => p.key)
                .ToList();

            if (parentNodes.Count() == 1)
            {
                Console.WriteLine(parentNodes[0]);
            }
            else if (parentNodes.Count() > 1)
            {
                Console.WriteLine("Multiple root nodes!");
            }
            else
            {
                Console.WriteLine("No root!");
            }
        }
    }
}