using System;

class Program
{
    static void Main()
    {
        string number = Convert.ToString((long)ulong.Parse(Console.ReadLine()), 2).PadLeft(64, '0');
        char[] bitsToSieve = number.ToCharArray();
        int nSieves = int.Parse(Console.ReadLine());
        int bits = 0;

        for (int i = 0; i < nSieves; i++)
        {
            string currentSieve = Convert.ToString((long)ulong.Parse(Console.ReadLine()), 2).PadLeft(64, '0');
            char[] currentBitsSieve = currentSieve.ToCharArray();

            for (int j = 0; j <= 63; j++)
            {
                if (bitsToSieve[j] == '1')
                {
                    if (currentBitsSieve[j] == '1')
                    {
                        bitsToSieve[j] = '0';
                    }
                }
            }
        }

        foreach (char bit in bitsToSieve)
        {
            if(bit == '1')
            {
                bits++;
            }
        }

        Console.WriteLine(bits);
    }
}