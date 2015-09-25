using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class VariationsWithoutRepetitions
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        int[] arr = new int[k];
        bool[] used = new bool[n + 1];

        GenerateVariations(arr, n, used);
    }

    private static void GenerateVariations(int[] arr, int setSize, bool[] used, int index = 0)
    {
        if (index >= arr.Length)
        {
            Print(arr);
        }
        else
        {
            for (int i = 1; i <= setSize; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    arr[index] = i;
                    GenerateVariations(arr, setSize, used, index + 1);
                    used[i] = false;
                }
            }
            
        }
    }

    private static void Print(int[] arr)
    {
        Console.WriteLine("({0})", string.Join(",", arr));
    }
}