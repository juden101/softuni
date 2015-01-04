using System;

public abstract class Person
{
    private string firstName;
    private string lastName;
    private byte age;

    public Person(string firstName, string lastName, byte age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            Utils.ValidateString(value, "FirstName", true);
            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            Utils.ValidateString(value, "LastName", true);
            this.lastName = value;
        }
    }

    public byte Age
    {
        get
        {
            return this.age;
        }

        set
        {
            if (value < 1 || value > 130)
            {
                throw new ArgumentOutOfRangeException("Age", "Age must be in range 1...130!");
            }

            this.age = value;
        }
    }
}