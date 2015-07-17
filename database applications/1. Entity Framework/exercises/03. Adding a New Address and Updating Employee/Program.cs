using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExercises
{
    class AddingANewAddressAndUpdatingEmployee
    {
        static void Main()
        {
            var context = new SoftUniEntities();

            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownID = 4
            };

            Employee employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employee.Address = address;

            context.SaveChanges();
        }
    }
}
