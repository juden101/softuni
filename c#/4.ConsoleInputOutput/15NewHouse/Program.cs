using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int dashes = n / 2;
        int asterisks = 1;

        for (int i = 0; i < n / 2 + 1; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('-', dashes), new string('*', asterisks));

            if (dashes > 0)
            {
                dashes--;
            }

            asterisks += 2;
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('|', 1), new string('*', n - 2));
        }
    }
}