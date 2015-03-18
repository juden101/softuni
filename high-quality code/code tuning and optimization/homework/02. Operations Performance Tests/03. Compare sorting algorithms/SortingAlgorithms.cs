using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class SortingAlgorithms
{
    public static void InsertionSort(IComparable[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int j = i + 1;

            while (j > 0 && array[j - 1].CompareTo(array[j]) > 0)
            {
                var temp = array[j - 1];
                array[j - 1] = array[j];
                array[j] = temp;
                j--;
            }
        }
    }

    public static void SelectionSort(IComparable[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i].CompareTo(array[j]) > 0)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }

    public static void Quicksort(IComparable[] elements, int left, int right)
    {
        int i = left;
        int j = right;
        IComparable pivot = elements[(left + right) / 2];

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
                IComparable temp = elements[i];
                elements[i] = elements[j];
                elements[j] = temp;

                i++;
                j--;
            }
        }

        if (left < j)
        {
            Quicksort(elements, left, j);
        }

        if (i < right)
        {
            Quicksort(elements, i, right);
        }
    }
}