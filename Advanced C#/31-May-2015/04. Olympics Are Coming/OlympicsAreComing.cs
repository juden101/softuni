using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class OlympicsAreComing
{
    static void Main()
    {
        string command;

        Dictionary<string, Dictionary<Athlete, int>> data = new Dictionary<string, Dictionary<Athlete, int>>();

        while ((command = Console.ReadLine()) != "report")
        {
            string[] commands = command.Split('|');

            string name = Regex.Replace(commands[0], @"\s+", " ").Trim();
            string country = Regex.Replace(commands[1], @"\s+", " ").Trim();

            if (!data.ContainsKey(country))
            {
                data.Add(country, new Dictionary<Athlete, int>());
            }

            Athlete currentAthlete = new Athlete()
            {
                Name = name
            };

            if (!data[country].ContainsKey(currentAthlete))
            {
                data[country].Add(currentAthlete, 0);
            }

            data[country][currentAthlete]++;
        }

        var output = data.OrderByDescending(c => c.Value.Sum(cc => cc.Value));

        foreach (var item in output)
        {
            Console.WriteLine("{0} ({1} participants): {2} wins", item.Key, item.Value.Count(), item.Value.Sum(i => i.Value));
        }
    }

    public class Athlete : IEquatable<Athlete>
    {
        public string Name { get; set; }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Athlete);
        }

        public bool Equals(Athlete other)
        {
            return other != null && this.Name == other.Name;
        }
    }
}