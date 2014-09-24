using System;

class Program
{
    static void Main()
    {
        int a;
        float b, c;

        Console.Write("a: ");
        a = int.Parse(Console.ReadLine());

        Console.Write("b: ");
        b = float.Parse(Console.ReadLine());

        Console.Write("c: ");
        c = float.Parse(Console.ReadLine());

        Console.WriteLine("|{0,-10:X}|{1,10:B}|{2,10:0.00}|{3,-10:0.000}|", a, Convert.ToString(a, 2).PadLeft(10, '0'), b, c);
    }
}