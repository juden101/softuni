using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] commands = command.Split(' ');

            if (commands[0] == "exchange")
            {
                int index = int.Parse(commands[1]);

                if (index < 1 || index > numbers.Count)
                {
                    Console.WriteLine("Invalid index");
                }

                var elementsToMove = numbers
                    .Skip(index + 1)
                    .ToArray();

                numbers.InsertRange(0, elementsToMove);
                numbers.RemoveRange(numbers.Count - elementsToMove.Length, elementsToMove.Length);
            }
            else if (commands[0] == "max")
            {
                if (commands[1] == "odd")
                {
                    int number = numbers.Where((k, v) => k % 2 != 0).OrderByDescending(x => x).First();

                    try
                    {
                        Console.WriteLine(numbers.LastIndexOf(number));
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("No matches");
                    }
                }
                else if (commands[1] == "even")
                {
                    int number = numbers.Where((k, v) => k % 2 == 0).OrderByDescending(x => x).First();

                    try
                    {
                        Console.WriteLine(numbers.LastIndexOf(number));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("No matches");
                    }
                }
            }
            else if (commands[0] == "min")
            {
                if (commands[1] == "odd")
                {
                    int number = numbers.Where((k, v) => k % 2 != 0).OrderBy(x => x).First();

                    try
                    {
                        Console.WriteLine(numbers.LastIndexOf(number));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("No matches");
                    }
                }
                else if (commands[1] == "even")
                {
                    try
                    {
                        int number = numbers.Where((k, v) => k % 2 == 0).OrderBy(x => x).First();
                        Console.WriteLine(numbers.LastIndexOf(number));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("No matches");
                    }
                }
            }
            else if (commands[0] == "first")
            {
                int elementsCount = int.Parse(commands[1]);

                if (elementsCount < 1 || elementsCount > numbers.Count)
                {
                    Console.WriteLine("Invalid count");
                    continue;
                }

                if (commands[2] == "odd")
                {
                    var found = numbers.Where((k, v) => k % 2 != 0).Take(elementsCount);
                    Console.WriteLine("[{0}]", string.Join(", ", found));
                }
                else if (commands[2] == "even")
                {
                    var found = numbers.Where((k, v) => k % 2 == 0).Take(elementsCount);
                    Console.WriteLine("[{0}]", string.Join(", ", found));
                }
            }
            else if (commands[0] == "last")
            {
                int elementsCount = int.Parse(commands[1]);

                if (elementsCount < 1 || elementsCount > numbers.Count)
                {
                    Console.WriteLine("Invalid count");
                    continue;
                }

                if (commands[2] == "odd")
                {
                    var found = numbers.Where((k, v) => k % 2 != 0).TakeLast(elementsCount);
                    Console.WriteLine("[{0}]", string.Join(", ", found));
                }
                else if (commands[2] == "even")
                {
                    var found = numbers.Where((k, v) => k % 2 == 0).TakeLast(elementsCount);
                    Console.WriteLine("[{0}]", string.Join(", ", found));
                }
            }
        }

        Console.WriteLine("[{0}]", string.Join(", ", numbers));
    }
}

public static class Extensions
{
    public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> collection, int n)
    {
        if (collection == null)
            throw new ArgumentNullException("collection");
        if (n < 0)
            throw new ArgumentOutOfRangeException("n", "n must be 0 or greater");

        LinkedList<T> temp = new LinkedList<T>();

        foreach (var value in collection)
        {
            temp.AddLast(value);
            if (temp.Count > n)
                temp.RemoveFirst();
        }

        return temp;
    }
}