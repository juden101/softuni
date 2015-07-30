using _01.EF_Mappings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _03.Export_Monasteries_by_Country
{
    class ExportMonasteriesAsXml
    {
        static void Main()
        {
            var context = new GeographyEntities();
            //select all the monasteries alphabetically along with all their countries alphabetically. 
            var monasteriesWithCountries = context.Countries
                .Where(c => c.Monasteries.Any())
                .OrderBy(c => c.CountryName)
                .Select(c => new
                {
                    c.CountryName,
                    Monasteries = c.Monasteries
                        .OrderBy(m => m.Name)
                        .Select(m => m.Name)
                });

            var xmlMonasteries = new XElement("monasteries");

            foreach (var country in monasteriesWithCountries)
            {
                var xmlCountry = new XElement("country");
                xmlCountry.Add(new XAttribute("name", country.CountryName));

                foreach (var monastery in country.Monasteries)
                {
                    xmlCountry.Add(new XElement("monastery", monastery));
                }

                xmlMonasteries.Add(xmlCountry);
            }

            File.WriteAllText("../../monasteries.xml", xmlMonasteries.ToString());
        }
    }
}
