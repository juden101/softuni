using System;

public abstract class Person : IPerson
{
    private string firstName;
    private string lastName;
    private int id;

    public Person(string firstName, string lastName, int id)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Id = id;
    }

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name can not be less than three characters.");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name can not be less than three characters.");
            }

            this.lastName = value;
        }
    }

    public int Id
    {
        get { return this.id; }
        set
        {
            if (value < 1 || value > 1000)
            {
                throw new ArgumentOutOfRangeException("ID", "ID shoul be in the range [1..1000]");
            }

            this.id = value;
        }
    }

    public override string ToString()
    {
        return String.Format("{0} {1}", this.firstName, this.lastName);
    }
}