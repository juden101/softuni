using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VariationsWithRepetitions
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        int[] arr = new int[k];

        GenerateVariations(arr, n);
    }

    private static void GenerateVariations(int[] arr, int setSize, int index = 0)
    {
        if (index >= arr.Length)
        {
            Print(arr);
        }
        else
        {
            for (int i = 1; i <= setSize; i++)
            {
                arr[index] = i;
                GenerateVariations(arr, setSize, index + 1);
            }
        }
    }

    private static void Print(int[] arr)
    {
        Console.WriteLine("({0})", string.Join(",", arr));
    }
}