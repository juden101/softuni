using System;

class Program
{
    static void Main()
    {
        double a, b, c, result = 0;

        Console.Write("a = ");
        a = double.Parse(Console.ReadLine());

        Console.Write("b = ");
        b = double.Parse(Console.ReadLine());

        Console.Write("c = ");
        c = double.Parse(Console.ReadLine());

        if (a > b && a > c)
        {
            result = a;
        }
        else if (b > a && b > c)
        {
            result = b;
        }
        else if(c > a && c > b)
        {
            result = c;
        }

        Console.WriteLine("result: {0}", result);
    }
}