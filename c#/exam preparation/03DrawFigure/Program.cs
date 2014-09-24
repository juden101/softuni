﻿using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(new string('*', n));

        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('.', i + 1), new string('*', n - (2 * (i + 1))));
        }

        if (n > 3)
        {
            for (int i = 0; i < n / 2 - 1; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string('.', (n / 2) - i - 1), new string('*', 3 + (2 * i)));
            }
        }

        Console.WriteLine(new string('*', n));
    }
}