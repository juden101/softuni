using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentException("Grade cannot be negative!");
        }

        if (minGrade < 0)
        {
            throw new ArgumentException("Min grade cannot be negative!");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Max grade cannot be less or equal than min grade!");
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentException("No comments added!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
