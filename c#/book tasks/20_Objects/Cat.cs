public class Cat : Animal
{
    public Cat(int age, string name, Gender gender)
        : base(age, name, gender)
    {
    }

    public override string MakeSound()
    {
        return "Miaauw";
    }
}