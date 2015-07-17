using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExercises
{
    class EmployeesWithSalaryOver50000
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            var employeeNames = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => e.FirstName);

            foreach (var employeeFirstName in employeeNames)
            {
                Console.WriteLine(employeeFirstName);
            }
        }
    }
}
