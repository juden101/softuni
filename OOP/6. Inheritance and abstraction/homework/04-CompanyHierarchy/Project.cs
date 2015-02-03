using System;

public class Project
{
    private string projectName;
    private DateTime projectStart;
    private string details;
    private ProjectState state;

    public Project(string projectName, DateTime projectStart, string details)
    {
        this.ProjectName = projectName;
        this.ProjectStart = projectStart;
        this.details = details;
    }

    public string ProjectName
    {
        get { return this.projectName; }
        protected set
        {
            if (value.Length < 1)
            {
                throw new ArgumentException("Project name can not be less than 1 charachter");
            }

            this.projectName = value;
        }
    }

    public DateTime ProjectStart
    {
        get { return this.projectStart; }
        protected set
        {
            if (value == null)
            {
                throw new ArgumentNullException("ProjectStart can not be empty");
            }

            this.projectStart = value;
        }
    }

    public string Details
    {
        get { return this.details; }
        protected set
        {
            if (value.Length < 1)
            {
                throw new ArgumentException("Details can not be less than 1 charachter");
            }

            this.details = value;
        }
    }

    public ProjectState State
    {
        get { return this.state; }
        protected set { this.state = ProjectState.Open; }
    }

    public void CloseProject()
    {
        if (this.state == ProjectState.Open)
        {
            this.state = ProjectState.Closed;
        }
        else
        {
            Console.WriteLine("The project is already cloesd.");
        }
    }

    public override string ToString()
    {
        return string.Format("{0} Start date: {1}, Details: {2}, State: {3}",
            this.projectName, this.projectStart, this.details, this.state);
    }
}