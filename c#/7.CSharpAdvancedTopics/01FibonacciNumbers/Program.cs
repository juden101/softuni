using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        Console.WriteLine(Fib(input));
    }

    static BigInteger Fib(int n)
    {
        BigInteger a = 0, b = 1, temp;

        for (int i = 0; i < n - 1; i++)
        {
            temp = a;
            a = b;
            b = temp + b;
        }

        return a + b;
    }
}