using System;
using System.Collections.Generic;
using System.Linq;

public class SumNumbers
{
    public static void Main()
    {
        Console.Write("Please enter numbers in format [n1 n2 n3 ... nk]: ");
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

        int sum = 0;

        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine("Sum: {0}", sum);
    }
}