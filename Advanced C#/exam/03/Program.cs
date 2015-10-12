using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        List<string> ints = new List<string>();
        List<string> doubles = new List<string>();

        string inputLine;
        StringBuilder sb = new StringBuilder();

        while((inputLine = Console.ReadLine()) != "//END_OF_CODE")
        {
            sb.AppendLine(inputLine);
        }

        string html = sb.ToString();
        string[] splited = Regex.Split(html, @"(?:\r\n){2,}");

        foreach (var item in splited)
        {
            HashSet<string> currentInts = new HashSet<string>();
            HashSet<string> currentDoubles = new HashSet<string>();

            Regex stringMatcher = new Regex(@"int[\s]+([^A-Z][\w]*?)([^\w]+)");
            MatchCollection matches = stringMatcher.Matches(item);

            foreach (Match match in matches)
            {
                string currentInt = match.Groups[1].ToString().Trim();
                currentInts.Add(currentInt);
            }

            Regex stringMatcher2 = new Regex(@"double[\s]+([^A-Z][\w]*?)([^\w]+)");
            MatchCollection matches2 = stringMatcher2.Matches(item);

            foreach (Match match in matches2)
            {
                string currentDouble = match.Groups[1].ToString().Trim();
                currentDoubles.Add(currentDouble);
            }

            ints.AddRange(currentInts);
            doubles.AddRange(currentDoubles);
        }

        if (doubles.Any())
        {
            Console.WriteLine("Doubles: {0}", string.Join(", ", doubles.OrderBy(x => x)));
        }
        else
        {
            Console.WriteLine("Doubles: None");
        }

        if (ints.Any())
        {
            Console.WriteLine("Ints: {0}", string.Join(", ", ints.OrderBy(x => x)));
        }
        else
        {
            Console.WriteLine("Ints: None");
        }
    }
}