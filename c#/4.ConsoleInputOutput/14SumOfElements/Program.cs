using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string sequence = Console.ReadLine();
        string[] sequenceOfNumbers = sequence.Split(' ');

        int maxNumber = 0;
        int sum = 0;

        for (int i = 0; i < sequenceOfNumbers.Length; i++)
        {
            int currentNumber = int.Parse(sequenceOfNumbers[i]);
            sum += currentNumber;

            if (currentNumber > maxNumber)
            {
                maxNumber = currentNumber;
            }
        }

        sum -= maxNumber;

        if(sum == maxNumber)
        {
            Console.WriteLine("Yes, sum={0}", sum);
        }
        else
        {
            int diff = 0;

            if (sum - maxNumber > 0)
            {
                diff = sum - maxNumber;
            }
            else if(maxNumber - sum > 0)
            {
                diff = maxNumber - sum;
            }

            Console.WriteLine("No, diff={0}", diff);
        }

    }
}