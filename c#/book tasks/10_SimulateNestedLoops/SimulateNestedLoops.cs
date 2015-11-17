using System;
using System.Linq;

public class SimulateNestedLoops
{
    private static int[] loops;

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        loops = new int[n];
        NestedLoops(0, n);
    }

    private static void NestedLoops(int currentLoop, int totalLoops)
    {
        if (currentLoop == totalLoops)
        {
            PrintLoops();
            return;
        }

        for (int counter = 1; counter <= totalLoops; counter++)
        {
            loops[currentLoop] = counter;
            NestedLoops(currentLoop + 1, totalLoops);
        }
    }

    private static void PrintLoops()
    {
        Console.WriteLine(string.Join(" ", loops.Select(x => x)));
    }
}