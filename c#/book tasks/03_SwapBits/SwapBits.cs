using System;

public class SwapBits
{
    public static void Main()
    {
        Console.Write("Please enter numer: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(isPrime(number));
    }

    public static bool isPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }

        if (number == 2)
        {
            return true;
        }

        for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}