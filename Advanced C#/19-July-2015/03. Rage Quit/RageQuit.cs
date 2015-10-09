using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class RageQuit
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        StringBuilder output = new StringBuilder();

        Regex regex = new Regex(@"(\D+)(\d+)");
        MatchCollection matches = regex.Matches(inputLine);

        foreach (Match match in matches)
        {
            int n = int.Parse(match.Groups[2].Value);

            for (int i = 0; i < n; i++)
            {
                output.Append(match.Groups[1].ToString().ToUpper());
            }
        }

        Console.WriteLine("Unique symbols used: {0}", output.ToString().Distinct().Count());
        Console.WriteLine(output.ToString());
    }
}