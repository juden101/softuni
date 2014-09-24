using System;

class Program
{
    static void Main()
    {
        int n;

        n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.Write("{0} ", i);
        }

        Console.WriteLine();
    }
}