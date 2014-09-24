using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[2*n];

        for(int i = 0; i < n*2; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int sumOfEvens = 0;
        int sumOfOdds = 0;

        for (int i = 0; i < n * 2; i++)
        {
            if(i % 2 == 0)
            {
                sumOfEvens += numbers[i];
            }
            else
            {
                sumOfOdds += numbers[i];
            }
        }

        if(sumOfEvens == sumOfOdds)
        {
            Console.WriteLine("Yes, sum={0}", sumOfOdds);
        }
        else
        {
            int diff = 0;

            if (sumOfEvens - sumOfOdds > 0)
            {
                diff = sumOfEvens - sumOfOdds;
            }
            else
            {
                diff = sumOfOdds - sumOfEvens;
            }

            Console.WriteLine("No, diff={0}", diff);
        }
    }
}