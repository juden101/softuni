using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        char[] bits = ConvertToBinary(n).PadLeft(64, '0').ToCharArray();
        int leftBits = 0;
        int rightBits = 0;

        for (int i = 0; i < 3; i++)
        {
            string[] data = Console.ReadLine().Split();

            int center = int.Parse(data[0]);
            int size = int.Parse(data[1]);

            int bitStart = center - size / 2;
            int bitEnd = center + size / 2;

            for (int j = bitStart; j <= bitEnd; j++)
            {
                if(j >= 0 && j < 64)
                {
                    bits[63 - j] = '0';
                }
            }
        }

        for (int i = 0; i < bits.Length; i++)
        {
            if (i > bits.Length / 2 - 1)
            {
                if (bits[i] == '1')
                {
                    rightBits++;
                }
            }
            else
            {
                if (bits[i] == '1')
                {
                    leftBits++;
                }
            }
        }

        Console.WriteLine("left: {0}", leftBits);
        Console.WriteLine("right: {0}", rightBits);
    }

    public static string ConvertToBinary(ulong value)
    {
        if (value == 0) return "0";
        System.Text.StringBuilder b = new System.Text.StringBuilder();

        while (value != 0)
        {
            b.Insert(0, ((value & 1) == 1) ? '1' : '0');
            value >>= 1;
        }

        return b.ToString();
    }
}