using System;

class Program
{
    static void Main()
    {
        int n, k, result;

        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());

        Console.Write("k = ");
        k = int.Parse(Console.ReadLine());

        result = Factorial(n) / Factorial(k);

        Console.WriteLine("result = {0}", result);
    }

    static int Factorial(int n)
    {
        int factorial = 1;

        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
        }

        return factorial;
    }
}