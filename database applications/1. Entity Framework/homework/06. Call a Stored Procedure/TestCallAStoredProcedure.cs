using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Call_a_Stored_Procedure
{
    public class TestCallAStoredProcedure
    {
        private static SoftUniEntities softUniEntities = new SoftUniEntities();

        public static void Main()
        {
            GetProjectsByEmpployee("Ruth", "Ellerbrock");
        }

        private static void GetProjectsByEmpployee(string firstName, string lastName)
        {
            var projects = softUniEntities.usp_SelectEmployeeProjects(firstName, lastName).ToList();

            foreach (var project in projects)
            {
                string description = project.Description.Substring(0, 30) + "...";
                string date = project.StartDate.ToString("M/d/yyyy hh:mm:ss tt");

                Console.WriteLine("{0} - {1}, {2}", project.Name, description, date);
            }
        }
    }
}