using System;
using Wintellect.PowerCollections;

public class StringEditor
{
    public static void Main()
    {
        BigList<char> editor = new BigList<char>();
        string input = Console.ReadLine();

        while(input != string.Empty)
        {
            var tokens = input.Split(' ');

            if (tokens[0] == "INSERT")
            {
                string inputString = tokens[1];

                editor.AddRangeToFront(tokens[1].ToCharArray());
                
                Console.WriteLine("OK");
            }
            else if (tokens[0] == "APPEND")
            {
                editor.AddRange(tokens[1].ToCharArray());

                Console.WriteLine("OK");
            }
            else if (tokens[0] == "DELETE")
            {
                int startIndex = int.Parse(tokens[1]);
                int count = int.Parse(tokens[2]);

                editor.RemoveRange(startIndex, count);

                Console.WriteLine("OK");
            }
            else if (tokens[0] == "PRINT")
            {
                Console.WriteLine(string.Join("", editor));
            }
            else
            {
                Console.WriteLine("Uknown command.");
            }

            input = Console.ReadLine();
        }
    }
}