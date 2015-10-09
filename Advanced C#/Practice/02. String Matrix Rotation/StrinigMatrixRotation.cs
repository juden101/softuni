using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class StrinigMatrixRotation
{
    static void Main(string[] args)
    {
        string rotateLine = Console.ReadLine();
        int rotation = 0;

        Regex regex = new Regex(@"(\d+)");
        Match match = regex.Match(rotateLine);

        if (match.Success)
        {
            rotation = int.Parse(match.Groups[1].Value);
        }

        List<string> lines = new List<string>();
        int maxLength = 0;

        string line = Console.ReadLine();
        lines.Add(line);

        if (line.Length > maxLength)
        {
            maxLength = line.Length;
        }


        while (line != "END")
        {
            line = Console.ReadLine();

            if (line != "END")
            {
                lines.Add(line);

                if (line.Length > maxLength)
                {
                    maxLength = line.Length;
                }
            }
        }

        char[,] matrix = new char[lines.Count, maxLength];

        for (int i = 0; i < lines.Count; i++)
        {
            char[] splitedLine = lines[i].ToCharArray();

            for (int j = 0; j < splitedLine.Length; j++)
            {
                matrix[i, j] = splitedLine[j];
            }
        }

        var output = matrix;

        if (rotation > 0)
        {
            for (int i = 0; i < rotation / 90; i++)
            {
                output = RotateMatrix(output);
            }
        }

        PrintMatrix(output);
    }

    private static void PrintMatrix(char[,] output)
    {
        for (int i = 0; i < output.GetLength(0); i++)
        {
            for (int j = 0; j < output.GetLength(1); j++)
            {
                if (output[i, j] == '\0')
                {
                    output[i, j] = ' ';
                }

                Console.Write(output[i, j]);
            }

            Console.WriteLine();
        }
    }

    static char[,] RotateMatrix(char[,] input)
    {
        int n = input.GetLength(0);
        int m = input.GetLength(1);
        char[,] output = new char[m, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                output[j, n - 1 - i] = input[i, j];
            }
        }
            
        return output;
    }
}