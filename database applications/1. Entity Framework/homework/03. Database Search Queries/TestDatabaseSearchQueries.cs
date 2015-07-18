using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Database_Search_Queries
{
    public class DatabaseSearchQueries
    {
        public static void Main()
        {
            var context = new SoftUniEntities();

            // 1. Find all employees who have projects started in the time period
            // 2001 - 2003 (inclusive). Select each employee's first name, last name
            // and manager name and each of their projects' name, start date, end date.

            var employees = context.Employees
                .Include("Employees.ManagerID")
                .Where(
                    e => e.Projects
                        .Any(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003))
                .Select(e => new {
                    firstName = e.FirstName,
                    lastName = e.LastName,
                    managerName = e.Employee1.FirstName + " " + e.Employee1.LastName,
                    projects = e.Projects
                });

            foreach (var employee in employees)
            {
                Console.WriteLine("Employee name: {0} {1}, Manager: {2} - {3} projects count",
                    employee.firstName,
                    employee.lastName,
                    employee.managerName,
                    employee.projects.Count);
            }
            
            // 2. Find all addresses, ordered by the number of employees who live
            // there (descending), then by town name (ascending). Take only the first
            // 10 addresses and select their address text, town name and employee count.
            
            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .Take(10)
                .Select(a => new {
                    address = a.AddressText,
                    town = a.Town.Name,
                    employeeCount = a.Employees.Count
                });

            Console.WriteLine("\r\nTask #2");

            foreach (var address in addresses)
            {
                Console.WriteLine("{0}, {1} - {2} employees", address.address, address.town, address.employeeCount);
            }

            //3. Get an employee by id (e.g. 147). Select only his/her
            // first name, last name, job title and projects (only their names).
            // The projects should be ordered by name (ascending).

            var singleEmployee = context.Employees
                .Where(e => e.EmployeeID == 147)
                .Select(e => new
                {
                    firstName = e.FirstName,
                    lastName = e.LastName,
                    jobTitle = e.JobTitle,
                    projects = e.Projects.Select(p => new
                    {
                        projectName = p.Name
                    })
                    .OrderBy(p => p.projectName)
                    .ToList()
                })
                .FirstOrDefault();

            Console.WriteLine("\r\nTask #3");
            Console.WriteLine("Employee name: {1} {2}{0}Job title: {3}{0}Projects count: {4}",
                "\r\n",
                singleEmployee.firstName,
                singleEmployee.lastName,
                singleEmployee.jobTitle,
                singleEmployee.projects.Count);
            

            // 4. Find all departments with more than 5 employees. Order them
            // by employee count (ascending). Select the department name, manager name
            // and first name, last name, hire date and job title of every employee.

            var departments = context.Departments
                .Include("Employees.ManagerID")
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .Select(d => new
                {
                    departmentName = d.Name,
                    managerName = d.Employee.LastName,
                    employees = d.Employees.Select(e => new
                    {
                        firstName = e.FirstName,
                        lastName = e.LastName,
                        hireDate = e.HireDate,
                        jobTitle = e.JobTitle
                    })
                    .ToList()
                })
                .ToList();

            Console.WriteLine("\r\nTask #4");
            Console.WriteLine(departments.Count);

            foreach (var department in departments)
            {
                Console.WriteLine("--{0} - Manager: {1}, Employees: {2}",
                    department.departmentName,
                    department.managerName,
                    department.employees.Count);
            }
        }
    }
}