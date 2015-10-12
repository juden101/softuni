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
        string inputLine;

        List<string> venues = new List<string>();
        Dictionary<string, Dictionary<string, int>> data = new Dictionary<string, Dictionary<string, int>>();

        while ((inputLine = Console.ReadLine()) != "End")
        {
            Regex stringMatcher = new Regex(@"(.*?)\s@(.*?)\s(\d+)\s(\d+)");
            var match = stringMatcher.Match(inputLine);

            if (!match.Success)
            {
                continue;
            }

            string singer = match.Groups[1].Value.Trim();
            string venue = match.Groups[2].Value.Trim();
            int ticketsPrice = int.Parse(match.Groups[3].Value.Trim());
            int ticketsCount = int.Parse(match.Groups[4].Value.Trim());

            if (!venues.Contains(venue))
            {
                venues.Add(venue);
            }

            if (!data.ContainsKey(venue))
            {
                data.Add(venue, new Dictionary<string, int>());
            }

            if (!data[venue].ContainsKey(singer))
            {
                data[venue].Add(singer, ticketsCount * ticketsPrice);
            }
            else
            {
                data[venue][singer] += ticketsCount * ticketsPrice;
            }
        }

        foreach (string venueName in venues)
        {
            Console.WriteLine(venueName);
            var sorted = data[venueName].OrderByDescending(x => x.Value);
			
            foreach (var concert in sorted)
            {
                Console.WriteLine("#  {0} -> {1}", concert.Key, concert.Value);
            }
        }
    }
}