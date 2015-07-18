using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Concurrent_Database_Changes
{
    class TestConcurrentDatabaseChanges
    {
        static void Main()
        {
            var firstContext = new SoftUniEntities();
            var secondContext = new SoftUniEntities();

            Employee firstEmployee = firstContext.Employees.FirstOrDefault(e => e.EmployeeID == 1);
            Employee secondEmployee = secondContext.Employees.FirstOrDefault(e => e.EmployeeID == 1);

            firstEmployee.FirstName = "Pesho";
            secondEmployee.FirstName = "Gosho";

            firstContext.SaveChanges();
            secondContext.SaveChanges();

            // when [Concurrency Mode] = "none" => Gosho is being writen
            // when [Concurrency Mode] = "fixed" => Pesho is being writen
        }
    }
}