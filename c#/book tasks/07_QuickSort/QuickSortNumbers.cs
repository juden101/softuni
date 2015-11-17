using System;

public class QuickSortNumbers
{
    public static void Main()
    {
        int[] numbers = { 3, 9, 1, 17, 9, 4, 25, -5, 6, -7, 13 };

        Console.WriteLine(string.Join(" ", numbers));
        QuickSort(numbers, 0, numbers.Length - 1);
        Console.WriteLine(string.Join(" ", numbers));
    }

    private static void QuickSort(int[] elements, int left, int right)
    {
        int i = left, j = right;
        int pivot = elements[(left + right) / 2];

        while (i <= j)
        {
            while (elements[i].CompareTo(pivot) < 0)
            {
                i++;
            }

            while (elements[j].CompareTo(pivot) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                int tmp = elements[i];
                elements[i] = elements[j];
                elements[j] = tmp;

                i++;
                j--;
            }
        }

        if (left < j)
        {
            QuickSort(elements, left, j);
        }

        if (i < right)
        {
            QuickSort(elements, i, right);
        }
    }
}