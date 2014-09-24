using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        char[] bits = Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(19, '0').ToCharArray();
        int f = 18 - int.Parse(Console.ReadLine());
        int r = int.Parse(Console.ReadLine());

        for (int i = 0; i < r; i++)
        {
            char[] newBits = new char[bits.Length];

            for (int j = 0; j < bits.Length; j++)
            {
                if(j == f)
                {
                    newBits[j] = bits[j];
                }
                else
                {
                    int newPosition = (j + 1) % bits.Length;

                    if(newPosition == f)
                    {
                        newPosition = (newPosition + 1) % bits.Length;
                    }

                    newBits[newPosition] = bits[j];
                }
            }

            for (int k = 0; k < bits.Length; k++)
            {
                bits[k] = newBits[k];
            }
        }

        int result = Convert.ToInt32(new string(bits), 2);
        Console.WriteLine(result);
    }
}