using System;

class Program
{
    static void Main()
    {
        int n;

        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine(i);
        }
    }
}