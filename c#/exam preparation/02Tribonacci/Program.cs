using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        BigInteger a = new BigInteger(int.Parse(Console.ReadLine()));
        BigInteger b = new BigInteger(int.Parse(Console.ReadLine()));
        BigInteger c = new BigInteger(int.Parse(Console.ReadLine()));
        int n = int.Parse(Console.ReadLine());
        BigInteger result;

        if (n == 1)
        {
            result = a;
        }
        else if (n == 2)
        {
            result = b;
        }
        else if (n == 3)
        {
            result = c;
        }
        else
        {
            for (int i = 4; i <= n; i++)
            {
                BigInteger tribNew = a + b + c;
                a = b;
                b = c;
                c = tribNew;
            }

            result = c;
        }

        Console.WriteLine(result);
    }
}