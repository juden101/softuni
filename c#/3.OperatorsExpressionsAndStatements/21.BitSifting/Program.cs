using System;

class Program
{
    static void Main()
    {
        ulong bits = ulong.Parse(Console.ReadLine());
        int sieves = int.Parse(Console.ReadLine());

        for (int i = 0; i < sieves; ++i)
        {
            ulong sieve = ulong.Parse(Console.ReadLine());
            bits = (bits ^ sieve) & bits;
        }

        int bitCount = 0;
        while (bits != 0)
        {
            bits &= (bits - 1);
            bitCount += 1;
        }
        Console.WriteLine(bitCount);
    }
}
