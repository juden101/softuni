using System;

class Program
{
    static void Main()
    {
        int n, x;
        decimal resultX, factorialN, s;

        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());

        Console.Write("x = ");
        x = int.Parse(Console.ReadLine());

        resultX = 1;
        factorialN = 1;
        s = 0;

        for (int i = 1; i <= n; i++)
        {
            factorialN *= i;
            resultX *= x;
            s += (factorialN / resultX);
        }

        Console.WriteLine("result = {0:F5}", 1 + s);
    }
}