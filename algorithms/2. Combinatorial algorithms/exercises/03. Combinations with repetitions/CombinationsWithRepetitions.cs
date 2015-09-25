using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CombinationsWithRepetitions
{
    static void Main()
    {
        int k = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        int[] arr = new int[k];

        GenerateCombinations(arr, arr.Length, 0);
    }

    private static void GenerateCombinations(int[] arr, int setSize, int index, int start = 1)
    {
        if (index >= arr.Length)
        {
            Print(arr);
        }
        else
        {
            for (int i = start; i <= setSize + 1; i++)
            {
                arr[index] = i;
                GenerateCombinations(arr, setSize, index + 1, i);
            }
        }
    }

    private static void Print(int[] arr)
    {
        Console.WriteLine("({0})", string.Join(",", arr));
    }
}