using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class CommandInterpreter
{
    static void Main()
    {
        string command;
        List<string> elements = Console.ReadLine()
            .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        while ((command = Console.ReadLine()) != "end")
        {
            try
            {
                string[] splittedCommand = command.Split();

                if (splittedCommand[0] == "reverse")
                {
                    int start = int.Parse(splittedCommand[2]);
                    int count = int.Parse(splittedCommand[4]);

                    if (start == elements.Count)
                    {
                        throw new ArgumentException();
                    }

                    elements.Reverse(start, count);
                }
                else if (splittedCommand[0] == "sort")
                {
                    int start = int.Parse(splittedCommand[2]);
                    int count = int.Parse(splittedCommand[4]);

                    if (start == elements.Count)
                    {
                        throw new ArgumentException();
                    }

                    elements.Sort(start, count, StringComparer.InvariantCulture);
                }
                else if (splittedCommand[0] == "rollLeft")
                {
                    int count = int.Parse(splittedCommand[1]) % elements.Count;

                    var elementsToMove = elements
                        .Take(count)
                        .ToArray();

                    elements.AddRange(elementsToMove);
                    elements.RemoveRange(0, count);
                }
                else if (splittedCommand[0] == "rollRight")
                {
                    int count = int.Parse(splittedCommand[1]) % elements.Count;

                    var elementsToMove = elements
                        .Skip(elements.Count - count)
                        .Take(count)
                        .ToArray();

                    elements.InsertRange(0, elementsToMove);
                    elements.RemoveRange(elements.Count - count, count);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Invalid input parameters.");
                continue;
            }
        }

        Console.WriteLine("[{0}]", string.Join(", ", elements));
    }
}