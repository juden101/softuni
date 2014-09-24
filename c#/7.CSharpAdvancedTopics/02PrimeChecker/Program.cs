using System;

class Program
{
    static void Main()
    {
        long input = long.Parse(Console.ReadLine());
        Console.WriteLine(isPrime(input));
    }

    static bool isPrime(long number)
    {
        if (number == 0) return false;
        if (number == 1) return false;
        if (number == 2) return true;

        for (long i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}