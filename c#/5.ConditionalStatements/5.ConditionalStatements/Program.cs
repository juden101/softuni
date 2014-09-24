using System;

class Program
{
    static void Main()
    {
        double a, b, c;

        Console.Write("a = ");
        a = double.Parse(Console.ReadLine());

        Console.Write("b = ");
        b = double.Parse(Console.ReadLine());

        if(a > b)
        {
            c = a;
            a = b;
            b = c;
        }

        Console.WriteLine("result: {0} {1}", a, b);
    }
}