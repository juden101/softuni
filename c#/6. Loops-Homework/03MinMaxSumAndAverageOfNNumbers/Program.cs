using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        double n, min, max, sum = 0, avg;

        List<int> numbers = new List<int>();

        n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());

            numbers.Add(currentNumber);

            sum += currentNumber;
        }

        numbers.Sort();

        min = numbers[0];
        max = numbers[numbers.Count - 1];
        avg = sum / n;

        Console.WriteLine("min = {0}", min);
        Console.WriteLine("max = {0}", max);
        Console.WriteLine("sum = {0}", sum);
        Console.WriteLine("avg = {0:N2}", avg);

        Console.WriteLine();
    }
}