using System;

public class Person : IComparable<Person>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int CompareTo(Person other)
    {
        return this.LastName.CompareTo(other.LastName);
    }

    public override string ToString()
    {
        return string.Format("{0} {1}", this.FirstName, this.LastName);
    }
}