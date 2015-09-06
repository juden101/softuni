namespace StacksAndQueuesHomework
{
    using System;
    using System.Collections.Generic;

    class CalculateSequenceWithAQueue
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> sequence = new Queue<int>(new int[] { n });
            int sequenceCount = 50;

            while (sequenceCount > 0)
            {
                int currentNumber = sequence.Dequeue();
                sequenceCount--;
                Console.Write("{0}, ", currentNumber);

                sequence.Enqueue(currentNumber + 1);
                sequence.Enqueue((2 * currentNumber) + 1);
                sequence.Enqueue(currentNumber + 2);
            }

            Console.WriteLine();
        }
    }
}