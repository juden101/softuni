using System;

class Program
{
    static void Main()
    {
        Console.Write("Please enter X: ");
        double x = double.Parse(Console.ReadLine());

        Console.Write("Please enter Y: ");
        double y = double.Parse(Console.ReadLine());

        bool isInCircle = (((Math.Pow(x - 1, 2) + (Math.Pow(y - 1, 2))) <= 1.5 * 1.5));
        bool isInRectangular = (x <= 5 && x >= -1) && (y >= -1 && y <= 1);

        if(isInCircle && !isInRectangular)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}