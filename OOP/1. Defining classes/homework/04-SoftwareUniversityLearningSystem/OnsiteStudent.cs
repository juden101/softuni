using System;

public class OnsiteStudent : CurrentStudent
{
    private ushort numberOfVisits;

    public OnsiteStudent(string firstName, string lastName, byte age, uint studentNumber, decimal averageGrade, string currentCourse, ushort numberOfVisits)
        : base(firstName, lastName, age, studentNumber, averageGrade, currentCourse)
    {
        this.NumberOfVisits = numberOfVisits;
    }

    public OnsiteStudent(string firstName, string lastName, byte age, uint studentNumber, decimal averageGrade, string currentCourse)
        : base(firstName, lastName, age, studentNumber, averageGrade, currentCourse)
    {
        this.NumberOfVisits = 0;
    }

    public ushort NumberOfVisits
    {
        get { return this.numberOfVisits; }
        set { this.numberOfVisits = value; }
    }
}