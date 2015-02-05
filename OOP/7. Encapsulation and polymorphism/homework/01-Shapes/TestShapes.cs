using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<IShape> shapes = new List<IShape>
        {
            new Triangle(3, 2, 2),
            new Rectangle(4, 9),
            new Circle(5)
        };

        foreach (var shape in shapes)
        {
            Console.WriteLine(shape.GetType().Name + ": ");
            Console.WriteLine(" Area: {0:f2}", shape.CalculateArea());
            Console.WriteLine(" Perimeter: {0:f2}", shape.CalculatePerimeter());
            Console.WriteLine();
        }
    }
}