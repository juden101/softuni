using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

public class EventsInGivenRange
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        var events = new OrderedMultiDictionary<DateTime, string>(true);
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine().Split('|');
            string eventName = tokens[0].Trim();
            DateTime eventDate = DateTime.Parse(tokens[1].Trim());

            events.Add(eventDate, eventName);
        }

        int rangesCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < rangesCount; i++)
        {
            string[] input = Console.ReadLine().Split('|');
            DateTime startDate = DateTime.Parse(input[0].Trim());
            DateTime endDate = DateTime.Parse(input[1].Trim());
            var eventsInRange = events.Range(startDate, true, endDate, true);
            
            Console.WriteLine(eventsInRange.KeyValuePairs.Count);

            foreach (var ev in eventsInRange)
            {
                foreach (var evValue in ev.Value)
                {
                    Console.WriteLine("{0} | {1}", evValue, ev.Key);
                }
            }
        }

        
    }
}