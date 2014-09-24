using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int start, end;
        string result = "";

        start = int.Parse(Console.ReadLine());
        end = int.Parse(Console.ReadLine());

        foreach (int primeNumber in FindPrimesInRange(start, end))
        {
            result += primeNumber.ToString() + ", ";
        }

        if(result.Length > 0)
        {
            Console.WriteLine(result.TrimEnd(new Char[] { ' ', ',' }));
        }
        else
        {
            Console.WriteLine("(empty list)");
        }
    }

    static List<int> FindPrimesInRange(int startNum, int endNum)
    {
        List<int> foundPrimes = new List<int>();

        for (int i = startNum; i <= endNum; i++)
        {
            if(isPrime(i))
            {
                foundPrimes.Add(i);
            }
        }

        return foundPrimes;
    }

    static bool isPrime(int number)
    {
        if (number == 0) return false;
        if (number == 1) return false;
        if (number == 2) return true;

        for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}