using System;

class Program
{
    static void Main()
    {
        long decimalNumber;
        string binary = "";

        Console.Write("decimal = ");
        decimalNumber = long.Parse(Console.ReadLine());

        while (decimalNumber != 0)
        {
            if(decimalNumber % 2 == 0)
            {
                binary = "0" + binary;
            }
            else
            {
                binary = "1" + binary;
            }

            decimalNumber /= 2;
        }

        if(binary == "")
        {
            binary = "0";
        }

        Console.WriteLine("binary = {0}", binary);
    }
}