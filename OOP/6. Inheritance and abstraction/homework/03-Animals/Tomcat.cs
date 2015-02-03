using System;

public class Tomcat : Cat, ISound
{
    public Tomcat(string name, int age)
        : base(name, age, "female")
    {
    }

    public override string ProduceSound()
    {
        return "phhh";
    }

    public void Piss()
    {
        Console.WriteLine("I'll piss all over your carpet");
    }

    public override string ToString()
    {
        return String.Format("I'm a tomcat ") + base.ToString();
    }
}