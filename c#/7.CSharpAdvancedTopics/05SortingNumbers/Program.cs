using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n;
        List<int> numbers = new List<int>();

        n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            numbers.Add(int.Parse(Console.ReadLine()));
        }

        numbers.Sort();

        Console.WriteLine();

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}