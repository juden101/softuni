using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter width: ");
        float width = float.Parse(Console.ReadLine());

        Console.Write("Enter height: ");
        float height = float.Parse(Console.ReadLine());

        float perimeter = (2 * width) + (2 * height);
        float area = width * height;

        Console.WriteLine("Perimeter: {0}, area: {1}", perimeter, area);
    }
}