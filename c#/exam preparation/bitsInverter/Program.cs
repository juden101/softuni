using System;
using System.Collections.Generic;

namespace bitsInverter
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int step = int.Parse(Console.ReadLine());
            string bits = "";
            List<string> extractedPairs = new List<string>();

            for (int i = 0; i < n; i++)
            {
                bits += Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
            }

            char[] invertedBits = bits.ToCharArray();

            for (int i = 0; i < bits.Length; i += step)
            {
                if (invertedBits[i] == '0')
                {
                    invertedBits[i] = '1';
                }
                else
                {
                    invertedBits[i] = '0';
                }
            }

            for (int i = 0; i < invertedBits.Length; i++)
            {
                if (extractedPairs.Count == 0)
                {
                    extractedPairs.Add(invertedBits[i].ToString());
                }
                else
                {
                    if (extractedPairs[extractedPairs.Count - 1].Length < 8)
                    {
                        extractedPairs[extractedPairs.Count - 1] += invertedBits[i].ToString();
                    }
                    else
                    {
                        extractedPairs.Add(invertedBits[i].ToString());
                    }
                }
            }

            foreach (string sequenceOfBits in extractedPairs)
            {
                Console.WriteLine(Convert.ToInt32(sequenceOfBits, 2));
            }
        }
    }
}