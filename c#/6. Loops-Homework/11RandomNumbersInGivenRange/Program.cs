using System;

class Program
{
    static void Main()
    {
        int n, min, max;
        Random randomNumber = new Random();

        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());

        Console.Write("min = ");
        min = int.Parse(Console.ReadLine());

        Console.Write("max = ");
        max = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", randomNumber.Next(min, max + 1));
        }

        Console.WriteLine();
    }
}