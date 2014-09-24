using System;

class Program
{
    static void Main()
    {
        double a, b, c, d, e, result = 0;

        Console.Write("a = ");
        a = double.Parse(Console.ReadLine());

        Console.Write("b = ");
        b = double.Parse(Console.ReadLine());

        Console.Write("c = ");
        c = double.Parse(Console.ReadLine());

        Console.Write("d = ");
        d = double.Parse(Console.ReadLine());

        Console.Write("e = ");
        e = double.Parse(Console.ReadLine());

        if (a >= b && a >= c && a >= d && a >= e)
        {
            result = a;
        }
        else if (b >= a && b >= c && b >= d && b >= e)
        {
            result = b;
        }
        else if (c >= a && c >= b && c >= d && c >= e)
        {
            result = c;
        }
        else if (d >= a && d >= b && d >= c && d >= e)
        {
            result = d;
        }
        else if (e >= a && e >= b && e >= c && e >= d)
        {
            result = e;
        }

        Console.WriteLine("result: {0}", result);
    }
}