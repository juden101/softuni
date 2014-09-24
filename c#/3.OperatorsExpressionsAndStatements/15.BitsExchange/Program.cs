using System;

class Program
{
    static void Main()
    {
        Console.Write("Please enter n: ");
        uint n = uint.Parse(Console.ReadLine());
        uint mask = 7;

        uint firstBits = (n & (mask << 3)) >> 3;
        uint secondBits = (n & (mask << 24)) >> 24;

        n = n & ~(mask << 3);
        n = n & ~(mask << 24);

        n = n | (firstBits << 24);
        n = n | (secondBits << 3);

        Console.WriteLine(n);
    }
}