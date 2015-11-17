public class Tomcat : Cat
{
    public Tomcat(int age, string name, Gender gender)
        : base(age, name, gender)
    {
    }

    public override string MakeSound()
    {
        return "Miaaaaw";
    }
}