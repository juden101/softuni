using System;
class Program
{
    static void Main()
    {
        double a, b, c, sum = 0;

        Console.Write("a: ");
        a = double.Parse(Console.ReadLine());

        Console.Write("b: ");
        b = double.Parse(Console.ReadLine());

        Console.Write("c: ");
        c = double.Parse(Console.ReadLine());

        sum = a + b + c;

        Console.WriteLine("sum: {0}", sum);
    }
}