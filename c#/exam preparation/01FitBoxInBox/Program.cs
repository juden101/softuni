using System;

class Program
{
    static void Main()
    {
        int w1 = int.Parse(Console.ReadLine());
        int h1 = int.Parse(Console.ReadLine());
        int d1 = int.Parse(Console.ReadLine());

        int w2 = int.Parse(Console.ReadLine());
        int h2 = int.Parse(Console.ReadLine());
        int d2 = int.Parse(Console.ReadLine());

        Fit(w1, h1, d1, w2, h2, d2);
        Fit(w1, h1, d1, w2, d2, h2);
        Fit(w1, h1, d1, h2, w2, d2);
        Fit(w1, h1, d1, h2, d2, w2);
        Fit(w1, h1, d1, d2, w2, h2);
        Fit(w1, h1, d1, d2, h2, w2);

        Fit(w2, h2, d2, w1, h1, d1);
        Fit(w2, h2, d2, w1, d1, h1);
        Fit(w2, h2, d2, h1, w1, d1);
        Fit(w2, h2, d2, h1, d1, w1);
        Fit(w2, h2, d2, d1, w1, h1);
        Fit(w2, h2, d2, d1, h1, w1);
    }

    static void Fit(int w1, int h1, int d1, int w2, int h2, int d2)
    {
        if(w1 < w2 && h1 < h2 && d1 < d2)
        {
            Console.WriteLine("({0}, {1}, {2}) < ({3}, {4}, {5})", w1, h1, d1, w2, h2, d2);
        }
    }
}