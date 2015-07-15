using System;
using System.Collections.Generic;
using System.Linq;

class SumAndAverage
{
    static void Main()
    {
        string input = Console.ReadLine();
        List<double> numbers = input.Split(' ').Select(Double.Parse).ToList();
        double sum = 0;
        double avg = 0.0;

        foreach (int currentNumber in numbers)
        {
            sum += currentNumber;
        }

        avg = sum / numbers.Count;

        Console.WriteLine("Sum={0}, Average={1}", sum, avg);
    }
}