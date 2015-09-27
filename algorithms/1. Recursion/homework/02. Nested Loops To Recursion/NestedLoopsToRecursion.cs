using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NestedLoopsToRecursion
{
    static int n;
    static int[] loops;

    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        loops = new int[n];
        NestedLoops(0);
    }

    static void NestedLoops(int currentLoop)
    {
        if (currentLoop == n)
        {
            PrintLoops();
            return;
        }

        for (int counter = 1; counter <= n; counter++)
        {
            loops[currentLoop] = counter;
            NestedLoops(currentLoop + 1);
        }
    }

    static void PrintLoops()
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", loops[i]);
        }

        Console.WriteLine();
    }
}