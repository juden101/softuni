using System;

class Program
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        int k = int.Parse(Console.ReadLine());

        inputLine = inputLine + " " + int.MaxValue;
        string[] inputTokens = inputLine.Split(' ');
        int equalCount = 1;
        int prev = int.Parse(inputTokens[0]);
        for (int i = 1; i < inputTokens.Length; i++)
        {
            int num = int.Parse(inputTokens[i]);
            if (num == prev)
            {
                equalCount++;
            }
            else
            {
                for (int counter = 0; counter < equalCount % k; counter++)
                {
                    Console.Write(prev + " ");
                }

                equalCount = 1;
            }

            prev = num;
        }
    }
}