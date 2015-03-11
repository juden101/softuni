using System;

public class CSharpExam : Exam
{
    public CSharpExam(int score)
    {
        if (score < 0)
        {
            throw new ArgumentException("Score cannot be less than 0!");
        }

        this.Score = score;
    }

    public int Score { get; private set; }

    public override ExamResult Check()
    {
        if (this.Score < 0 || this.Score > 100)
        {
            throw new ArgumentException("Score cannot be less than 0 or grater than 100!");
        }

        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
    }
}
