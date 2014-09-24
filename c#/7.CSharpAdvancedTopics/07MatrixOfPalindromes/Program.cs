using System;

class Program
{
    static void Main()
    {
        int a, b;

        string[] chars = Console.ReadLine().Split();

        a = Convert.ToInt32(chars[0]);
        b = Convert.ToInt32(chars[1]);

        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                Console.Write("{0}{1}{0} ", (char)(97 + i), (char)(97 + i + j));
            }

            Console.WriteLine();
        }
    }
}