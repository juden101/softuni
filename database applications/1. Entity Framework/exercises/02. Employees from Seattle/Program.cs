using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExercises
{
    class EmployeesFromSeattle
    {
        static void Main()
        {
            var context = new SoftUniEntities();
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        Department = e.Department.Name,
                        e.Salary
                    }
                );

            foreach (var employee in employees)
            {
                Console.WriteLine("{0} {1}, {2}, {3}",
                    employee.FirstName,
                    employee.LastName,
                    employee.Department,
                    employee.Salary);
            }
        }
    }
}
