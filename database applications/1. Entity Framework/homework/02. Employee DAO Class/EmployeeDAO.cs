using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Employee_DAO_Class
{
    public static class EmployeeDAO
    {
        private static SoftUniEntities softuniEntities = new SoftUniEntities();

        public static void Add(Employee employee)
        {
            softuniEntities.Employees.Add(employee);
            softuniEntities.SaveChanges();
        }

        public static Employee FindByKey(int id)
        {
            Employee employee = softuniEntities.Employees
                .Where(e => e.EmployeeID == id)
                .FirstOrDefault();

            return employee;
        }

        public static void Modify(int employeeId, string newFirstName)
        {
            Employee employee = FindByKey(employeeId);
            employee.FirstName = newFirstName;
            softuniEntities.SaveChanges();
        }

        public static void Delete(int employeeId)
        {
            Employee employee = FindByKey(employeeId);
            softuniEntities.Employees.Remove(employee);
            softuniEntities.SaveChanges();
        }
    }
}