public class Kitten : Cat
{
    public Kitten(int age, string name, Gender gender)
        : base(age, name, gender)
    {
    }

    public override string MakeSound()
    {
        return "Miaw";
    }
}