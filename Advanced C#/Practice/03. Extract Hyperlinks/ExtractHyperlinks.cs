using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class ExtractHyperlinks
{
    static void Main()
    {
        string inputLine;
        StringBuilder html = new StringBuilder();
        Queue<string> output = new Queue<string>();

        while ((inputLine = Console.ReadLine()) != "END")
        {
            html.AppendLine(inputLine);
        }
        
        Regex regex = new Regex(@"<a\s+[^>]*?\bhref\s*?=\s*?(""|')(?<href>[\S\s]*?)(\1)[\S\s]*?>");
        MatchCollection matches = regex.Matches(html.ToString());

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Groups["href"].Value);
        }
    }
}