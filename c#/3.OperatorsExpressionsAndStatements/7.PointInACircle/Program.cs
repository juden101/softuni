using System;

class Program
{
    static void Main()
    {
        int radius = 2;

        Console.Write("Please enter X: ");
        double x = double.Parse(Console.ReadLine());

        Console.Write("Please enter Y: ");
        double y = double.Parse(Console.ReadLine());

        bool isInCircle = (((x * x) + (y * y)) <= radius * radius);
        Console.WriteLine(isInCircle);
    }
}