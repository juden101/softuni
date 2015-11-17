using System;

public class First100Numbers
{
    public static void Main()
    {
        for (int i = 2; i < 103; i++)
        {
            int currentNumber = i;

            if (currentNumber % 2 != 0)
            {
                currentNumber *= -1;
            }

            Console.WriteLine(currentNumber);
        }
    }
}