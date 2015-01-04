using System;

public class GraduateStudent : Student
{
    public GraduateStudent(string firstName, string lastName, byte age, uint studentNumber, decimal averageGrade)
        : base(firstName, lastName, age, studentNumber, averageGrade)
    {
    }
}