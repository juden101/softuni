using System;

class Program
{
    static void Main()
    {
        string hexadecimalNumber;
        long decimalNumber = 0;

        Console.Write("hexadecimal = ");
        hexadecimalNumber = Console.ReadLine();

        for (int i = 0; i < hexadecimalNumber.Length; i++)
        {
            decimalNumber += Convert.ToInt32(hexNumber(hexadecimalNumber[i].ToString())) * IntPow(16, (long)(hexadecimalNumber.Length - i - 1));
        }

        Console.WriteLine("decimal = {0}", decimalNumber);
    }

    static int hexNumber(string hexChar)
    {
        switch (hexChar)
        {
            case "0":
                return 0;
            case "1":
                return 1;
            case "2":
                return 2;
            case "3":
                return 3;
            case "4":
                return 4;
            case "5":
                return 5;
            case "6":
                return 6;
            case "7":
                return 7;
            case "8":
                return 8;
            case "9":
                return 9;
            case "A":
                return 10;
            case "B":
                return 11;
            case "C":
                return 12;
            case "D":
                return 13;
            case "E":
                return 14;
            case "F":
                return 15;
            default:
                break;
        }

        return 0;
    }

    public static long IntPow(int x, long pow)
    {
        long result = 1;
        for (long i = 0; i < pow; i++)
        {
            result *= x;
        }

        return result;
    }
}