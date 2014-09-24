using System;

class Program
{
    static void Main()
    {
        float manWeightOnEarth = float.Parse(Console.ReadLine());
        float manWeightOnMoon = (manWeightOnEarth * 17) / 100;

        Console.WriteLine("{0}", manWeightOnMoon);
    }
}