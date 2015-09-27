using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TowerOfHanoi
{
    private static Stack<int> source = new Stack<int>();
    private static Stack<int> destination = new Stack<int>();
    private static Stack<int> spare = new Stack<int>();

    private static int stepsTaken = 0;

    static void Main()
    {
        int bottomDisk = Setup();

        MoveDisks(bottomDisk, source, destination, spare);

        Console.WriteLine(stepsTaken);
    }

    private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
    {
        stepsTaken++;

        if (bottomDisk == 1)
        {
            destination.Push(source.Pop());
        }
        else
        {
            MoveDisks(bottomDisk - 1, source, spare, destination);
            destination.Push(source.Pop());
            MoveDisks(bottomDisk - 1, spare, destination, source);
        }
    }

    private static int Setup()
    {
        int diskNumber = int.Parse(Console.ReadLine());

        for (int count = diskNumber; count >= 1; count--)
        {
            source.Push(count);
        }

        return diskNumber;
    }
}