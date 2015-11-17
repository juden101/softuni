public abstract class Animal
{
    private int age;
    private string name;
    private Gender gender;

    public Animal(int age, string name, Gender gender)
    {
        this.age = age;
        this.name = name;
        this.gender = gender;
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public Gender Gender
    {
        get { return this.gender; }
        set { this.gender = value; }
    }

    public virtual string MakeSound()
    {
        return "I'm animal";
    }

    public override string ToString()
    {
        return string.Format("I`m {0}, {1} years old and my gender is {2}. {3}", this.Name, this.Age, this.Gender, this.MakeSound());
    }
}