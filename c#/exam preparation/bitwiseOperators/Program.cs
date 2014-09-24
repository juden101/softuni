using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] normalNumbers = new int[n];
        int[] invertedNumbers = new int[n];
        int[] reversedNumbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            int normalNumber = int.Parse(Console.ReadLine());
            char[] currentBits = Convert.ToString(normalNumber, 2).ToCharArray();
            string invertedBits = "";
            string reversedBits = "";

            foreach (char bit in currentBits)
            {
                if(bit == '1')
                {
                    invertedBits += "0";
                }
                else
                {
                    invertedBits += "1";
                }
            }
            
            for (int j = currentBits.Length - 1; j > -1; j--)
            {
                reversedBits += currentBits[j];
            }

            normalNumbers[i] = normalNumber;
            invertedNumbers[i] = Convert.ToInt32(invertedBits, 2);
            reversedNumbers[i] = Convert.ToInt32(reversedBits, 2);
        }
        
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine((normalNumbers[i] ^ invertedNumbers[i]) & reversedNumbers[i]);
        }
    }
}