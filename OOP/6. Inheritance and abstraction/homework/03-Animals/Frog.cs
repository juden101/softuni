using System;

// define a class Frog which derives from Anmal and implements ISound
public class Frog : Animal, ISound
{
    public Frog(string name, int age, string gender)
        : base(name, age, gender)
    {
    }

    public override string ProduceSound()
    {
        return "kvak";
    }

    public void Jump()
    {
        Console.WriteLine("Now I'll jump on your head.");
    }

    public override string ToString()
    {
        return String.Format("I'm a frog ") + base.ToString();
    }

}