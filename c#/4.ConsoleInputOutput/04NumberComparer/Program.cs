using System;
class Program
{
    static void Main()
    {
        double a, b, greater;

        Console.Write("a: ");
        a = double.Parse(Console.ReadLine());

        Console.Write("b: ");
        b = double.Parse(Console.ReadLine());

        greater = a > b ? a : b;
        Console.WriteLine("greater: {0}", greater);
    }
}