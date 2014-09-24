using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        string top = new string('.', (n - 1) / 2) + new string('#', n) + new string('.', (n - 1) / 2);
        Console.WriteLine(top);

        string topMiddle = new string('.', (n - 1) / 2) + "#" + new string('.', n - 2) + "#" + new string('.', (n - 1) / 2);
        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine(topMiddle);
        }

        string middle = new string('#', (n + 1) / 2) + new string('.', n - 2) + new string('#', (n + 1) / 2);
        Console.WriteLine(middle);

        int outerDots = 1;
        int innerDots = 2 * n - 5;
        for (int i = 0; i < n - 2; i++)
        {
            string middleBottom = new string('.', outerDots) + "#" + new string('.', innerDots) + "#" + new string('.', outerDots);
            Console.WriteLine(middleBottom);
            outerDots += 1;
            innerDots -= 2;
        }

        string bottom = new string('.', outerDots) + "#" + new string('.', outerDots);
        Console.WriteLine(bottom);
    }
}