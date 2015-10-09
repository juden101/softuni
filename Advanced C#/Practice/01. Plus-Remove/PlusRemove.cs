using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PlusRemove
{
    public static void Main()
    {
        List<char[]> chars = new List<char[]>();
        List<char[]> output = new List<char[]>();

        string line = Console.ReadLine();

        if (line != "END")
        {
            chars.Add(line.ToCharArray());
            output.Add(line.ToCharArray());
        }

        while(line != "END")
        {
            line = Console.ReadLine();

            if (line != "END")
            {
                chars.Add(line.ToCharArray());
                output.Add(line.ToCharArray());
            }
        }
        
        for (int i = 0; i < chars.Count; i++)
        {
            for (int j = 0; j < chars[i].Length; j++)
            {
                if (j - 1 < 0 ||
                    i + 2 >= chars.Count ||
                    j >= chars[i + 2].Length ||
                    j + 1 >= chars[i + 1].Length)
                {
                    continue;
                }

                char a = Char.ToLower(chars[i][j]);
                char b = Char.ToLower(chars[i + 1][j]);
                char c = Char.ToLower(chars[i + 2][j]);
                char d = Char.ToLower(chars[i + 1][j - 1]);
                char e = Char.ToLower(chars[i + 1][j + 1]);

                if (a == b && b == c && c == d && d == e)
                {
                    output[i][j] = '\0';
                    output[i + 1][j] = '\0';
                    output[i + 2][j] = '\0';
                    output[i + 1][j - 1] = '\0';
                    output[i + 1][j + 1] = '\0';
                }
            }
        }

        for (int i = 0; i < chars.Count; i++)
        {
            for (int j = 0; j < chars[i].Length; j++)
            {
                if (output[i][j] != '\0')
                {
                    Console.Write(output[i][j]);
                }
            }

            Console.WriteLine();
        }
    }
}