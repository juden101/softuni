using System;

public class FibonacciNumbers
{
    private static int[] numbers;

    public static void Main()
    {
        Console.Write("Please enter number: ");
        int fibNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Result: {0}", CalculateFibonacci(fibNumber));
    }

    private static int CalculateFibonacci(int n)
    {
        if (n < 1)
        {
            return 0;
        }

        if (numbers == null)
        {
            numbers = new int[n];
        }

        if (numbers[n - 1] == 0)
        {
            if (n <= 2)
            {
                numbers[n - 1] = n - 1;
            }
            else
            {
                numbers[n - 1] = CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
            }
        }

        return numbers[n - 1];
    }
}