using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CombinationsWithoutRepetition
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int[] arr = new int[k];

        GenerateCombinations(0, arr, 1, n);
    }

    private static void GenerateCombinations(int index, int[] arr, int startNum, int endNum)
    {
        if (index >= arr.Length)
        {
            Print(arr);

            return;
        }

        for (int i = startNum; i <= endNum; i++)
        {
            arr[index] = i;
            GenerateCombinations(index + 1, arr, i + 1, endNum);
        }
    }

    private static void Print(int[] arr)
    {
        Console.WriteLine(string.Join(" ", arr));
    }
}