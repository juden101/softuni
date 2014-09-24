using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        int n;
        BigInteger result;

        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());

        result = (Factorial(2 * n)) / ((Factorial(n + 1)) * Factorial(n));
        Console.WriteLine("result = {0}", result);
    }

    static BigInteger Factorial(int n)
    {
        BigInteger factorial = 1;

        for (int i = 1; i <= n; i++)
        {
            factorial *= (BigInteger)i;
        }

        return factorial;
    }
}