using System;

public class RandomNumbersInGivenRange
{
    public static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());

        Random randomNumber = new Random();

        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", randomNumber.Next(1, n + 1));
        }

        Console.WriteLine();
    }
}