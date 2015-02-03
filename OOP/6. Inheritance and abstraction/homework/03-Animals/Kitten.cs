using System;

public class Kitten : Cat, ISound
{
    public Kitten(string name, int age)
        : base(name, age, "female")
    {
    }

    public override string ProduceSound()
    {
        return "miaw";
    }

    public void Cry()
    {
        Console.WriteLine("I'm so cute I'll make you cry");
    }

    public override string ToString()
    {
        return String.Format("I'm a kiiten ") + base.ToString();
    }

}