public class Dog : Animal
{
    public Dog(int age, string name, Gender gender)
        : base(age, name, gender)
    {
    }

    public override string MakeSound()
    {
        return "Bark";
    }
}