using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int dots = n / 2;
        int asterisks = 1;
        int sideRoof = n / 2 - 1;
        int middleRoof = 1;
        int wall = n / 4;

        for (int i = 0; i < n / 2 + 1; i++)
        {
            if(i == 0)
            {
                Console.WriteLine("{0}{1}{0}", new string('.', dots), new string('*', asterisks));
            }
            else if (i == n / 2)
            {
                Console.WriteLine("{0}", new string('*', n));
            }
            else
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', sideRoof--), new string('*', 1), new string('.', middleRoof));
                middleRoof += 2;
            }

        }

        for (int i = 0; i < n / 2; i++)
        {
            if(i == n / 2 - 1)
            {
                Console.WriteLine("{0}{1}{0}", new string('.', wall), new string('*', n - 2*wall));
            }
            else
            {
                Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', wall), new string('*', 1), new string('.', n - 2 * wall - 2));
            }
        }
    }
}