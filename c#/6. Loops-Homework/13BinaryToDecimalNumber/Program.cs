using System;

class Program
{
    static void Main()
    {
        string binary;
        int decimalNumber = 0;

        Console.Write("binary = ");
        binary = Console.ReadLine();
        
        for (int i = 0; i < binary.Length; i++)
        {
            decimalNumber += ((int)binary[i] - 48) * IntPow(2, (uint)(binary.Length - i - 1));
        }

        Console.WriteLine("decimal = {0}", decimalNumber);
    }

    public static int IntPow(int x, uint pow)
    {
        int result = 1;
        for (int i = 0; i < pow; i++)
        {
            result *= x;
        }

        return result;
    }
}