using System;

class Program
{
    static void Main()
    {
        Console.Write("Please enter a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Please enter b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Please enter h: ");
        double h = double.Parse(Console.ReadLine());

        double area = ((a + b) * h) / 2;
        Console.WriteLine("Trapezoid's area: {0}", area);
    }
}