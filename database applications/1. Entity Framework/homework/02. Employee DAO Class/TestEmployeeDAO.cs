using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Employee_DAO_Class
{
    class TestEmployeeDAO
    {
        static void Main(string[] args)
        {
            // inserts an employee
            Employee newEmployee = new Employee
            {
                FirstName = "Pesho",
                LastName = "Peshev",
                JobTitle = "Technical Trainer",
                DepartmentID = 1,
                HireDate = new DateTime(2015, 7, 17),
                Salary = 1000
            };

            EmployeeDAO.Add(newEmployee);

            // prints employee
            Employee employee = EmployeeDAO.FindByKey(1);
            Console.WriteLine(employee);

            // changes employee first name
            EmployeeDAO.Modify(2, "Gosho");

            // deletes an employee
            EmployeeDAO.Delete(2);
        }
    }
}
