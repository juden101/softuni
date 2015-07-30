using _01.EF_Mappings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace _02.Export_rivers_as_JSON
{
    class ExportRiversAsJSON
    {
        static void Main()
        {
            var context = new GeographyEntities();
            var rivers = context.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
                {
                    r.RiverName,
                    r.Length,
                    Countries = r.Countries
                        .OrderBy(c => c.CountryName)
                        .Select(c => c.CountryName)
                })
                .ToList();

            var jsSerializer = new JavaScriptSerializer();
            var riverJson = jsSerializer.Serialize(rivers);

            File.WriteAllText("../../rivers-output.json", riverJson);
        }
    }
}
