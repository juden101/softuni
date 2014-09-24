using System;

class Program
{
    static void Main()
    {
        char[] bits = Convert.ToString(uint.Parse(Console.ReadLine()), 2).ToCharArray();
        string friendBits = "";
        string aloneBits = "";

        string lastBit = "";
        string currentBit = "";
        string nextBit = "";

        for (int i = 0; i < bits.Length; i++)
		{
	        currentBit = bits[i].ToString();
            lastBit = "";
            nextBit = "";

            if(i - 1 >= 0)
            {
                lastBit = bits[i - 1].ToString();
            }

            if (i + 1 < bits.Length)
            {
                nextBit = bits[i + 1].ToString();
            }

            if(lastBit == "")
            {
                if(currentBit == nextBit)
                {
                    friendBits += currentBit;
                }
                else
                {
                    aloneBits += currentBit;
                }
            }
            else if(nextBit == "")
            {

                if (currentBit == lastBit)
                {
                    friendBits += currentBit;
                }
                else
                {
                    aloneBits += currentBit;
                }
            }
            else
            {
                if (currentBit == nextBit)
                {
                    friendBits += currentBit;
                }
                else if (currentBit == lastBit)
                {
                    friendBits += currentBit;
                }
                else
                {
                    aloneBits += currentBit;
                }
            }
		}

        Console.WriteLine(Convert.ToInt32(friendBits.PadLeft(8, '0'), 2));
        Console.WriteLine(Convert.ToInt32(aloneBits.PadLeft(8, '0'), 2));
    }
}