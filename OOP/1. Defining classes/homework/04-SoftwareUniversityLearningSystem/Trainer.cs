using System;

public abstract class Trainer : Person
{
    public Trainer(string firstName, string lastName, byte age)
        : base(firstName, lastName, age)
    {
    }

    public void CreateCourse(string courseName)
    {
        Console.WriteLine(string.Format("{0} {1}, you created the course: {2}", this.FirstName, this.LastName, courseName));
    }
}