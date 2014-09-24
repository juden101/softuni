using System;

class Program
{
    static void Main()
    {
        double a, b, c;
        string result = "";

        Console.Write("a = ");
        a = double.Parse(Console.ReadLine());

        Console.Write("b = ");
        b = double.Parse(Console.ReadLine());

        Console.Write("c = ");
        c = double.Parse(Console.ReadLine());

        if (a >= b && a >= c && b >= c)
        {
            result = a + " " + b + " " + c;
        }
        else if (a >= b && a >= c && c >= b)
        {
            result = a + " " + c + " " + b;
        }
        else if (b >= a && b >= c && a >= c)
        {
            result = b + " " + a + " " + c;
        }
        else if (b >= a && b >= c && c >= a)
        {
            result = b + " " + c + " " + a;
        }
        else if (c >= a && c >= b && a >= b)
        {
            result = c + " " + a + " " + b;
        }
        else if (c >= a && c >= b && b >= a)
        {
            result = c + " " + b + " " + a;
        }

        Console.WriteLine("result: {0}", result);
    }
}