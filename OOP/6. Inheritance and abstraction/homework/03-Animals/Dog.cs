using System;

public class Dog : Animal, ISound
{
    public Dog(string name, int age, string gender)
        : base(name, age, gender)
    {
    }

    public override string ProduceSound()
    {
        return "bau";
    }

    public void FetchStick()
    {
        Console.WriteLine("Throw me a stick and I'll fetch it for you.");
    }

    public override string ToString()
    {
        return String.Format("I'm a dog ") + base.ToString();
    }
}