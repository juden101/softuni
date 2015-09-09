using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

public class StringEditor
{
    static void Main()
    {
        BigList<char> editor = new BigList<char>();
        string input = Console.ReadLine();
        Queue<string> output = new Queue<string>();

        while (input != string.Empty)
        {
            var tokens = input.Split(' ');

            if (tokens[0] == "INSERT")
            {
                int startPosition = int.Parse(tokens[1]);
                string inputString = tokens[2];

                if (startPosition < 0 || startPosition > editor.Count)
                {
                    output.Enqueue("ERROR");
                }
                else
                {
                    editor.InsertRange(startPosition, inputString.ToCharArray());

                    output.Enqueue("OK");
                }
            }
            else if (tokens[0] == "APPEND")
            {
                editor.AddRange(tokens[1].ToCharArray());
                
                output.Enqueue("OK");
            }
            else if (tokens[0] == "DELETE")
            {
                int startIndex = int.Parse(tokens[1]);
                int count = int.Parse(tokens[2]);

                if (startIndex < 0 || count < 0 || startIndex + count > editor.Count)
                {
                    output.Enqueue("ERROR");
                }
                else
                {
                    editor.RemoveRange(startIndex, count);

                    output.Enqueue("OK");
                }
            }
            else if (tokens[0] == "REPLACE")
            {
                int startIndex = int.Parse(tokens[1]);
                int count = int.Parse(tokens[2]);
                string newString = tokens[3];

                if (startIndex < 0 || count < 0 || startIndex + count > editor.Count)
                {
                    output.Enqueue("ERROR");
                }
                else
                {
                    editor.RemoveRange(startIndex, count);
                    editor.InsertRange(startIndex, newString);

                    output.Enqueue("OK");
                }
            }
            else if (tokens[0] == "PRINT")
            {
                output.Enqueue(string.Join("", editor));
            }
            else if (tokens[0] == "END")
            {
                break;
            }
            else
            {
                output.Enqueue("Uknown command.");
            }

            input = Console.ReadLine();
        }

        Console.WriteLine();

        foreach (string outputLine in output)
        {
            Console.WriteLine(outputLine);
        }
    }
}