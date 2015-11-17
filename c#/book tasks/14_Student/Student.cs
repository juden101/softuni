using System;

public class Student
{
    private static int counter = 0;

    private string firstName;
    private string middleName;
    private string lastName;
    private string course;
    private string degree;
    private string university;
    private string email;
    private string phoneNumber;

    public Student()
    {
        counter++;
    }

    public Student(string firstName, string middleName, string lastName,
        string course, string degree, string university, string email, string phoneNumber)
        : this()
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.Course = course;
        this.Degree = degree;
        this.University = university;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
    }

    public Student(string firstName, string middleName, string lastName)
        : this()
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
    }

    public Student(string firstName, string lastName)
        : this()
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public Student(string firstName, string lastName, string email, string phoneNumber)
        : this()
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
    }

    public string FirstName
    {
        get { return this.firstName; }
        set { this.firstName = value; }
    }

    public string MiddleName
    {
        get { return this.middleName; }
        set { this.middleName = value; }
    }

    public string LastName
    {
        get { return this.lastName; }
        set { this.lastName = value; }
    }

    public string Course
    {
        get { return this.course; }
        set { this.course = value; }
    }

    public string Degree
    {
        get { return this.degree; }
        set { this.degree = value; }
    }

    public string University
    {
        get { return this.university; }
        set { this.university = value; }
    }

    public string Email
    {
        get { return this.email; }
        set { this.email = value; }
    }

    public string PhoneNumber
    {
        get { return this.phoneNumber; }
        set { this.phoneNumber = value; }
    }

    public override string ToString()
    {
        return string.Format(
            "Student #{9}: {1} {2} {3}{0}Course: {4}{0}Degree: {5}{0}University: {6}{0}Email: {7}{0}Phone number: {8}{0}",
            Environment.NewLine,
            this.FirstName,
            this.MiddleName,
            this.LastName,
            this.Course ?? "(no info)",
            this.Degree ?? "(no info)",
            this.University ?? "(no info)",
            this.Email ?? "(no info)",
            this.PhoneNumber ?? "(no info)",
            counter);
    }
}