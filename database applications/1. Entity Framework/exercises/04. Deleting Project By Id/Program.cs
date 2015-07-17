using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExercises
{
    class DeletingProjectById
    {
        static void Main()
        {
            var context = new SoftUniEntities();

            var project = context.Projects.Find(2);
            var projectEmployees = project.Employees;

            foreach (var projectEmployee in projectEmployees)
            {
                projectEmployee.Projects.Remove(project);
            }

            context.Projects.Remove(project);

            context.SaveChanges();
        }
    }
}