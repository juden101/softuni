using System;

class Program
{
    static void Main()
    {
        double r, perimeter, area;

        Console.Write("Circle radius: ");
        r = double.Parse(Console.ReadLine());

        perimeter = 2 * Math.PI * r;
        area = Math.PI * Math.Pow(r, 2);

        Console.WriteLine("Perimeter: {0:0.00}", perimeter);
        Console.WriteLine("Area: {0:0.00}", area);
    }
}