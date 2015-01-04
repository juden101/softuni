using System;

public abstract class Student : Person
{
    private uint studentNumber;
    private decimal averageGrade;

    public Student(string firstName, string lastName, byte age, uint studentNumber, decimal averageGrade)
        : base(firstName, lastName, age)
    {
        this.StudentNumber = studentNumber;
        this.AverageGrade = averageGrade;
    }

    public uint StudentNumber
    {
        get
        {
            return this.studentNumber;
        }

        set
        {
            if (value > 999999999U)
            {
                throw new ArgumentOutOfRangeException("StudentNumber", "StudentNumber must be in range 0...999999999");
            }

            this.studentNumber = value;
        }
    }

    public decimal AverageGrade
    {
        get
        {
            return this.averageGrade;
        }

        set
        {
            if (value > 6M || value < 3M)
            {
                throw new ArgumentOutOfRangeException("AverageGrade", "AverageGrade must be in range 3...6");
            }

            this.averageGrade = value;
        }
    }
}