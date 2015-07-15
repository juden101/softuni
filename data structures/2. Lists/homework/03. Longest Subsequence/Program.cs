using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LongestSubsequence
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        List<int> numbers = input.Split(' ').Select(int.Parse).ToList();
        List<int> result = new List<int>(numbers.Count);

        int count = 1;
        int maxCount = 1;
        int currentNumber = numbers[0];

        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] == numbers[i - 1])
            {
                count++;

                if (count > maxCount)
                {
                    maxCount = count;
                    currentNumber = numbers[i];
                }
            }
            else
            {
                count = 1;
            }
        }

        for (int i = 0; i < maxCount; i++)
        {
            result.Add(currentNumber);
        }

        Console.WriteLine(String.Join(" ", result));
    }
}