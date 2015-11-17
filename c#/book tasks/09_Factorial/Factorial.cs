using System;
using System.Collections.Generic;
using System.Numerics;

public class Factorial
{
    public static void Main()
    {
        Dictionary<int, BigInteger> computedFactorials = ComputeFactorials(100);

        Console.WriteLine("5! = {0}", computedFactorials[5]);
        Console.WriteLine("17! = {0}", computedFactorials[17]);
        Console.WriteLine("53! = {0}", computedFactorials[53]);
        Console.WriteLine("100! = {0}", computedFactorials[100]);
    }

    private static Dictionary<int, BigInteger> ComputeFactorials(int n)
    {
        Dictionary<int, BigInteger> factorials = new Dictionary<int, BigInteger>();
        factorials.Add(0, new BigInteger(1));

        for (int i = 1; i <= n; i++)
        {
            BigInteger fact = new BigInteger(i) * (factorials[i - 1]);
            factorials.Add(i, fact);
        }

        return factorials;
    }
}