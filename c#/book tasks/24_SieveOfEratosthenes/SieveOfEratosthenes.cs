using System;

public class SieveOfEratosthenes
{
    public static void Main()
    {
        long n = 500;
        bool[] prime = new bool[n];

        for (int i = 2; i < n; i++)
        {
            prime[i] = true;
        }

        for (int j = 2; j < n; j++)
        {
            if (prime[j])
            {
                for (long p = 2; (p * j) < n; p++)
                {
                    prime[p * j] = false;
                }
            }
        }

        for (int i = 2; i < n; i++)
        {
            if (prime[i])
            {
                Console.Write("{0} ", i);
            }
        }

        Console.WriteLine();
    }
}