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

            List<char> livedBits = new List<char>();
            foreach (char bit in bits)
            {
                livedBits.Add(bit);
            }

            for (int i = 1; i < livedBits.Count; i += step - 1)
            {
                livedBits.RemoveAt(i);
            }

            for (int i = 0; i < livedBits.Count; i++)
            {
                if (extractedPairs.Count == 0)
                {
                    extractedPairs.Add(livedBits[i].ToString());
                }
                else
                {
                    if (extractedPairs[extractedPairs.Count - 1].Length < 8)
                    {
                        extractedPairs[extractedPairs.Count - 1] += livedBits[i].ToString();
                    }
                    else
                    {
                        extractedPairs.Add(livedBits[i].ToString());
                    }
                }
            }

            foreach (string sequenceOfBits in extractedPairs)
            {
                Console.WriteLine(Convert.ToInt32(sequenceOfBits.PadRight(8, '0'), 2));
            }
        }
    }
}