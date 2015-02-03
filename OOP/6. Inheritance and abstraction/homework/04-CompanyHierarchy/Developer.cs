using System;
using System.Collections.Generic;
using System.Text;

public class Developer : RegularEmployee, IDeveloper
{
    private List<Project> projectsList;

    public Developer(string firstname, string lastname, int id, decimal salary, Department department,
        List<Project> projectsList)
        : base(firstname, lastname, id, salary, department)
    {
        this.ProjectsList = projectsList;
    }

    public List<Project> ProjectsList
    {
        get { return this.projectsList; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Project List", "Project list can not be empty");
            }

            this.projectsList = value;
        }
    }

    // override the ToString() method
    public override string ToString()
    {
        StringBuilder projects = new StringBuilder();
        projects.AppendLine("List of projects:");

        foreach (var project in this.projectsList)
        {
            projects.AppendLine(project.ToString());
        }

        return base.ToString() + projects.ToString();
    }
}