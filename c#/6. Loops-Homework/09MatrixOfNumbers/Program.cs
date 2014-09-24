using System;

class Program
{
    static void Main()
    {
        int n, index = 1;

        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(j + index);
            }

            index++;
            Console.WriteLine();
        }
    }
}