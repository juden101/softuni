namespace _05.EF_Code_First
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    class ConsoleClient
    {
        static void Main()
        {
            Database.SetInitializer(new MountainMigrationStrategy());

            /*Country c = new Country()
            {
                Code = "AB",
                Name = "Absurdistan"
            };

            Mountain m = new Mountain()
            {
                Name = "Absurdistan Hills"
            };

            Peak p1 = new Peak()
            {
                Name = "Great peak",
                Mountain = m
            };

            Peak p2 = new Peak()
            {
                Name = "Small peak",
                Mountain = m
            };

            m.Peaks.Add(p1);
            m.Peaks.Add(p2);
            c.Mountains.Add(m);*/

            var context = new MountainsContext();
            //context.Countries.Add(c);
            //context.SaveChanges();

            var countriesQuery = context.Countries
                .Select(c => new
                {
                    CountryName = c.Name,
                    Mountains = c.Mountains.Select(m => new
                    {
                        m.Name,
                        m.Peaks
                    })
                });

            foreach (var country in countriesQuery)
            {
                Console.WriteLine("Country name: {0}", country.CountryName);

                foreach (var mountain in country.Mountains)
                {
                    Console.WriteLine("  Mountain: {0}", mountain.Name);

                    foreach (var peak in mountain.Peaks)
                    {
                        Console.WriteLine("    {0} ({1})", peak.Name, peak.Elevation);
                    }
                }
            }
        }
    }
}