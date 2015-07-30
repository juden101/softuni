using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.EF_Mappings
{
    class ListContinents
    {
        static void Main()
        {
            var context = new GeographyEntities();

            foreach (var continent in context.Continents)
            {
                Console.WriteLine(continent.ContinentName);
            }
        }
    }
}
