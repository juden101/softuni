using System;

public class OnlineStudent : CurrentStudent
{
    public OnlineStudent(string firstName, string lastName, byte age, uint studentNumber, decimal averageGrade, string currentCourse)
        : base(firstName, lastName, age, studentNumber, averageGrade, currentCourse)
    {
    }
}