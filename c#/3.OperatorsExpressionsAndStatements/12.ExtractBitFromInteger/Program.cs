using System;

class Program
{
    static void Main()
    {
        Console.Write("Please enter n: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Please enter p: ");
        int p = int.Parse(Console.ReadLine());

        int nRightP = n >> p;
        int bit = nRightP & 1;

        Console.WriteLine(bit);
    }
}