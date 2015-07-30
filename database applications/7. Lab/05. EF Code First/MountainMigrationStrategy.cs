using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.EF_Code_First
{
    public class MountainMigrationStrategy :
        DropCreateDatabaseIfModelChanges<MountainsContext>
    {
        protected override void Seed(MountainsContext context)
        {
            var bulgaria = new Country { Code = "BG", Name = "Bulgaria" };
            var germany = new Country { Code = "DE", Name = "Germany" };

            context.Countries.Add(bulgaria);
            context.Countries.Add(germany);

            var rila = new Mountain { Name = "Rila", Countries = { bulgaria } };
            var pirin = new Mountain { Name = "Pirin", Countries = { bulgaria } };
            var rhodopes = new Mountain { Name = "Rhodopes", Countries = { bulgaria } };

            context.Mountains.Add(rila);
            context.Mountains.Add(pirin);
            context.Mountains.Add(rhodopes);

            var musala = new Peak { Name = "Musala", Elevation = 2925, Mountain = rila };
            var malyovitsa = new Peak { Name = "Malyovitsa", Elevation = 2729, Mountain = rila };
            var vihren = new Peak { Name = "Vihren", Elevation = 2914, Mountain = pirin };

            context.Peaks.Add(musala);
            context.Peaks.Add(malyovitsa);
            context.Peaks.Add(vihren);
        }
    }
}
