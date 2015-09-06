namespace StacksAndQueuesHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SequenceNToM
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split();

            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            SolveTheSequence(n, m);
        }

        private static void SolveTheSequence(int n, int m)
        {
            Queue<Item> items = new Queue<Item>();
            items.Enqueue(new Item(n, null));

            while (items.Count > 0)
            {
                Item currentItem = items.Dequeue();

                if (currentItem.Value < m)
                {
                    items.Enqueue(new Item(currentItem.Value * 2, currentItem));
                    items.Enqueue(new Item(currentItem.Value + 2, currentItem));
                    items.Enqueue(new Item(currentItem.Value + 1, currentItem));
                }

                if (currentItem.Value == m)
                {
                    PrintSequenceSolution(currentItem);

                    break;
                }
            }

            if (items.Count == 0)
            {
                Console.WriteLine("(No solution)");
            }
        }

        private static void PrintSequenceSolution(Item item)
        {
            Stack<int> sequence = new Stack<int>();

            while (item.PrevItem != null)
            {
                sequence.Push(item.Value);
                item = item.PrevItem;

                if (item.PrevItem == null)
                {
                    sequence.Push(item.Value);
                }
            }

            Console.WriteLine(string.Join(" -> ", sequence));
        }
    }
}