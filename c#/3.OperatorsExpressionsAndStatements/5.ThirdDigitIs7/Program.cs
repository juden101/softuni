using System;

class Program
{
    static void Main()
    {
        Console.Write("Please enter number: ");
        int number = int.Parse(Console.ReadLine());

        bool isSeven = (number / 100) % 10 == 7;
        Console.WriteLine(isSeven);
    }
}