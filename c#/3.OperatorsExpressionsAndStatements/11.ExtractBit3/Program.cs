using System;

class Program
{
    static void Main()
    {
        Console.Write("Please enter number: ");
        int n = int.Parse(Console.ReadLine());

        int p = 3;
        int nRightP = n >> p;
        int bit = nRightP & 1;

        Console.WriteLine(bit);    
    }
}