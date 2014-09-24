using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalfSum
{
    class Program
    {
        static void Main()
        {
            int numbers = int.Parse(Console.ReadLine());
            int[] firstSequence = new int[numbers];
            int[] secondSequence = new int[numbers];
            int firstSequenceSum = 0;
            int secondSequenceSum = 0;

            for (int i = 0; i < numbers * 2; i++)
            {
                if(i < (numbers * 2 / 2))
                {
                    firstSequence[i] = int.Parse(Console.ReadLine());
                }
                else
                {
                    secondSequence[i - numbers] = int.Parse(Console.ReadLine());
                }
            }

            foreach (int number in firstSequence)
            {
                firstSequenceSum += number;
            }

            foreach (int number in secondSequence)
            {
                secondSequenceSum += number;
            }

            if (firstSequenceSum == secondSequenceSum)
            {
                Console.WriteLine("Yes, sum=" + firstSequenceSum);
            }
            else
            {
                if (firstSequenceSum > secondSequenceSum)
                {
                    Console.WriteLine("No, diff=" + (firstSequenceSum - secondSequenceSum));
                }
                else
                {
                    Console.WriteLine("No, diff=" + (secondSequenceSum - firstSequenceSum));
                }
            }
        }
    }
}
