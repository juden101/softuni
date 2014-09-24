using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        int n, trailingZeroes = 0, five = 5;

        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());

        while (five < n)
        {
            trailingZeroes += n / five;
            five *= 5;
        }

        Console.WriteLine("trailing zeroes = {0}", trailingZeroes);
    }
}