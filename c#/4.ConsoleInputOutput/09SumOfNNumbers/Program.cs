using System;

class Program
{
    static void Main()
    {
        int n;
        double sum = 0;

        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            sum += double.Parse(Console.ReadLine());
        }

        Console.WriteLine("sum = {0}", sum);
    }
}