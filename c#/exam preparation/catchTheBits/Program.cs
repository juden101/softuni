using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        string sequenceOfBits = "";
        List<string> extractedPairs = new List<string>();

        for (int i = 0; i < n; i++)
		{
			 sequenceOfBits += Convert.ToString(int.Parse(Console.ReadLine()), 2).PadLeft(8, '0');
		}

        for (int i = 1; i < sequenceOfBits.Length; i += step)
		{
            if (extractedPairs.Count == 0)
            {
                extractedPairs.Add(sequenceOfBits[i].ToString());
            }
            else
            {
                if (extractedPairs[extractedPairs.Count - 1].Length < 8)
                {
                    extractedPairs[extractedPairs.Count - 1] += sequenceOfBits[i].ToString();
                }
                else
                {
                    extractedPairs.Add(sequenceOfBits[i].ToString());
                }
            }
		}

        foreach (string bits in extractedPairs)
        {
            Console.WriteLine(Convert.ToInt32(bits.PadRight(8, '0'), 2));
        }
    }
}