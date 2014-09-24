using System;

class Program
{
    static void Main()
    {
        char[] bits = Convert.ToString((long)ulong.Parse(Console.ReadLine()), 2).PadLeft(64, '0').ToCharArray();

        for (int i = 0; i < bits.Length; i++)
        {
            if(i + 2 > 63)
            {
                break;
            }

            if(bits[i] == '0' && bits[i + 1] == '0' && bits[i + 2] == '0')
            {
                bits[i] = '1';
                bits[i + 1] = '1';
                bits[i + 2] = '1';

                i += 2;
            }
            else if (bits[i] == '1' && bits[i + 1] == '1' && bits[i + 2] == '1')
            {
                bits[i] = '0';
                bits[i + 1] = '0';
                bits[i + 2] = '0';

                i += 2;
            }
        }

        ulong result = (ulong)Convert.ToInt64(new string(bits), 2);
        Console.WriteLine(result);
    }
}