using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("{0}{1}{0}", new string('-', n / 2), new string('*', 1));

        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("{0}{1}{2}{1}{0}", new string('-', n / 2 - 1 - i), new string('*', 1), new string('-', 1 + i * 2));
        }

        int innerDashes = n - 2;

        Console.WriteLine("{0}{1}{0}", new string('*', 1), new string('-', innerDashes));

        for (int i = 0; i < n / 2 - 1; i++)
        {
            innerDashes -= 2;
            Console.WriteLine("{0}{1}{2}{1}{0}", new string('-', 1 + i), new string('*', 1), new string('-', innerDashes));
        }

        Console.WriteLine("{0}{1}{0}", new string('-', n / 2), new string('*', 1));
    }
}