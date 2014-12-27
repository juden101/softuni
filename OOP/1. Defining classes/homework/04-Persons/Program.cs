using System;

class Program
{
    static void Main()
    {
        Person me = new Person();
        me.Name = "Ivan";
        me.Age = 18;
        me.Email = "asd@";
        Console.WriteLine(me.Name);
        Console.WriteLine(me.Age);
    }
}

class Person
{

    private String name;
    private int age;
    private String email;

    public Person(String name, int age, String email)
    {

    }

    public String Name
    {
        get { return this.name; }
        set
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cannot be empty.");
            }

            this.name = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        set
        {
            if (value < 1 || value > 100)
            {
                throw new ArgumentNullException("Age should be in range [1 .. 100].");
            }

            this.age = value;
        }
    }

    public String Email
    {
        get { return this.email; }
        set
        {
            if (!String.IsNullOrEmpty(value) && !value.Contains("@"))
            {
                throw new ArgumentNullException("Email should be either empty or valid.");
            }

            this.email = value;
        }
    }

}