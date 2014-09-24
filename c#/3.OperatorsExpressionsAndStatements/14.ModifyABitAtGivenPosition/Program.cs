using System;

class Program
{
    static void Main()
    {
        Console.Write("Please enter n: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Please enter p: ");
        int p = int.Parse(Console.ReadLine());

        Console.Write("Please enter v: ");
        int v = int.Parse(Console.ReadLine());

        // Get the bit at the position p
        int mask = 1 << p;
        int nAndMask = n & mask;
        int bit = nAndMask >> p;

        if (bit != v && bit == 0)
        {
            int result = n | mask;
            Console.WriteLine(result);
        }
        if (bit != v && bit == 1)
        {
            int mask2 = ~(1 << p);
            int result = n & mask2;
            Console.WriteLine(result);
        }
        if (bit == v)
        {
            Console.WriteLine(n);
        }


    }
}