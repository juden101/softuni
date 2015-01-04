using System;
using System.Text;

public class DropoutStudent : Student
{
    private string dropoutReason;

    public DropoutStudent(string firstName, string lastName, byte age, uint studentNumber, decimal averageGrade, string dropoutReason)
        : base(firstName, lastName, age, studentNumber, averageGrade)
    {
        this.DropoutReason = dropoutReason;
    }

    public string DropoutReason
    {
        get
        {
            return this.dropoutReason;
        }

        set
        {
            Utils.ValidateString(value, "DropoutReason", true);
            this.dropoutReason = value;
        }
    }

    public void Reapply()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(new string('-', 30));
        sb.AppendLine(string.Format("First name: {0}", this.FirstName));
        sb.AppendLine(string.Format("Last name: {0}", this.LastName));
        sb.AppendLine(string.Format("Age: {0}", this.Age));
        sb.AppendLine(string.Format("Student number: {0}", this.StudentNumber));
        sb.AppendLine(string.Format("Average grade: {0}", this.AverageGrade));
        sb.AppendLine("Dropout reason:");
        sb.AppendLine(string.Format("    {0}", this.DropoutReason));
        sb.AppendLine(new string('-', 30));
        Console.WriteLine(sb.ToString());
    }
}