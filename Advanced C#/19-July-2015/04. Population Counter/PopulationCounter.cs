using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class PopulationCounter
{
    static void Main()
    {
        string command;

        Dictionary<string, HashSet<City>> data = new Dictionary<string, HashSet<City>>();

        while ((command = Console.ReadLine()) != "report")
        {
            string[] commands = command.Split('|');

            string city = commands[0];
            string country = commands[1];
            long population = long.Parse(commands[2]);

            if (!data.ContainsKey(country))
            {
                data.Add(country, new HashSet<City>());
            }

            City currentCity = new City()
            {
                Name = city,
                Population = population
            };

            data[country].Add(currentCity);
        }

        var output = data.OrderByDescending(c => c.Value.Sum(cc => cc.Population));

        foreach (var item in output)
        {
            Console.WriteLine("{0} (total population: {1})", item.Key, data[item.Key].Sum(c => c.Population));
            
            var cities = item.Value.OrderByDescending(c => c.Population);
            foreach (var city in cities)
            {
                Console.WriteLine("=>{0}: {1}", city.Name, city.Population);
            }
        }
    }

    public class City
    {
        public string Name { get; set; }

        public long Population { get; set; }
    }
}