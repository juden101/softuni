namespace _04.Import_Rivers_from_XML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using _01.EF_Mappings;
    using System.Xml.Linq;
    using System.Xml.XPath;

    class ImportRiversFromXML
    {
        static void Main()
        {
            var xmlDoc = XDocument.Load("../../rivers.xml");
            var riverNodes = xmlDoc.XPathSelectElements("/rivers/river");
            foreach (var riverNode in riverNodes)
            {
                string riverName = riverNode.Element("name").Value;
                int riverLength = int.Parse(riverNode.Element("length").Value);
                string riverOutflow = riverNode.Element("outflow").Value;
                int? drainageArea = null;
                int? averageDischarge = null;

                if (riverNode.Element("drainage-area") != null) 
                {
                    drainageArea = int.Parse(riverNode.Element("drainage-area").Value);
                }

                if (riverNode.Element("average-discharge") != null)
                {
                    averageDischarge = int.Parse(riverNode.Element("average-discharge").Value);
                }

                var context = new GeographyEntities();
                var river = new River()
                {
                    RiverName = riverName,
                    Length = riverLength,
                    Outflow = riverOutflow,
                    DrainageArea = drainageArea,
                    AverageDischarge = averageDischarge
                };

                var countryNodes = riverNode.XPathSelectElements("countries/country");
                var countryNames = countryNodes.Select(c => c.Value);
                foreach (var countryName in countryNames)
                {
                    var country = context.Countries
                        .FirstOrDefault(c => c.CountryName == countryName);
                    river.Countries.Add(country);
                }

                context.Rivers.Add(river);
                context.SaveChanges();
            }
        }
    }
}