using System;

class Program
{
    static void Main()
    {
        short n;

        Console.Write("n = ");
        n = short.Parse(Console.ReadLine());

        if(n <= 0 || n > 9)
        {
            Console.WriteLine("invalid score");
        }
        else
        {
            if (n >= 1 && n <= 3)
            {
                n *= 10;
            }
            else if (n >= 4 && n <= 6)
            {
                n *= 100;
            }
            else if (n >= 7 && n <= 9)
            {
                n *= 1000;
            }

            Console.WriteLine("n = {0}", n);
        }
    }
}