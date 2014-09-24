using System;

class Program
{
    static void Main()
    {
        int n;
        Random randomNumber = new Random();

        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", randomNumber.Next(1, n + 1));
        }

        Console.WriteLine();
    }
}