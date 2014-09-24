using System;

class Program
{
    static void Main()
    {
        Console.Write("Please enter numer: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine(isPrime(number));
    }
    static bool isPrime(int number)
    {

        if (number == 1)
        {
            return false;
        }

        if (number == 2)
        {
            return true;
        }

        for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}