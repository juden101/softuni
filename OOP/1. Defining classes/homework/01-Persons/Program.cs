using System;

class Program
{
    static void Main()
    {
        try
        {
            Person ivan = new Person("Ivan", 18, "ivan@gmail.com");
            Person pesho = new Person("Pesho", 43, "");
            Person gosho = new Person("Gosho", 27);

            Console.WriteLine(ivan.ToString());
            Console.WriteLine("########################");
            Console.WriteLine(pesho.ToString());
            Console.WriteLine("########################");
            Console.WriteLine(gosho.ToString());
        }
        catch (ArgumentNullException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.ParamName);
            Console.ResetColor();
        }
    }
}

class Person
{

    private string name;
    private int age;
    private string email;

    public Person(string name, int age, String email)
    {
        this.Name = name;
        this.Age = age;
        this.Email = email;
    }

    public Person(string name, int age)
        : this(name, age, "")
    {

    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value))
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

    public string Email
    {
        get { return this.email; }
        set
        {
            if (!string.IsNullOrEmpty(value) && !value.Contains("@"))
            {
                throw new ArgumentNullException("Email should be either empty or valid.");
            }

            this.email = value;
        }
    }

    public override string ToString()
    {
        string output = "Person: " + this.Name + ", " + this.Age;

        if (!string.IsNullOrEmpty(this.Email))
        {
            output += ", " + this.Email;
        }

        return output;
    }

}