using System;
class Program
{
    static void Main()
    {
        double a, b, c, d, x, x1, x2;

        Console.Write("a = ");
        a = double.Parse(Console.ReadLine());

        Console.Write("b = ");
        b = double.Parse(Console.ReadLine());

        Console.Write("c = ");
        c = double.Parse(Console.ReadLine());

        d = Math.Pow(b, 2) - (4 * a * c);

        if(d > 0)
        {
            x1 = ((-b) - Math.Sqrt(d)) / (2 * a);
            x2 = ((-b) + Math.Sqrt(d)) / (2 * a);

            Console.WriteLine("x1={0}; x2={1}", x1, x2);
        }
        else if(d == 0)
        {
            x = (-b) / (2 * a);
            Console.WriteLine("x1=x2={0}", x);
        }
        else
        {
            Console.WriteLine("no real roots");
        }
    }
}