using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Native_SQL_Query
{
    /// <summary>
    /// Finds all employees who have projects with start date in the year 2002.
    /// Selects only their first name.
    /// </summary>
    public class NativeSQLQuery
    {
        private static SoftUniEntities context = new SoftUniEntities();

        public static void Main()
        {
            var totalCount = context.Employees.Count();

            var sw = new Stopwatch();
            sw.Start();

            PrintNamesWithNativeQuery();
            Console.WriteLine("Native: {0}", sw.Elapsed);

            sw.Restart();

            PrintNamesWithLinqQuery();
            Console.WriteLine("Linq: {0}", sw.Elapsed);
        }

        public static void PrintNamesWithNativeQuery()
        {
            var employeeNames = context.Database.SqlQuery<string>(
                @"SELECT FirstName
                FROM Employees AS е
                WHERE EXISTS(
                    SELECT *
                    FROM EmployeesProjects AS ep
                    INNER JOIN Projects AS p
                        ON p.ProjectID = ep.ProjectID
                    WHERE
                        (е.EmployeeID = ep.EmployeeID) AND
                        ((DATEPART (YEAR, p.StartDate)) = 2002)
                    )")
                .ToList();

            foreach (var employeeName in employeeNames)
            {
                //Console.WriteLine(employeeName);
            }
        }

        public static void PrintNamesWithLinqQuery()
        {
            var employeeNames = context.Employees
                .Where(e => e.Projects.Any(p => p.StartDate.Year == 2002))
                .Select(e => e.FirstName)
                .ToList();

            foreach (var employeeName in employeeNames)
            {
                //Console.WriteLine(employeeName);
            }
        }
    }
}