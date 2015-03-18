using System;
using System.Diagnostics;

class CompareSortingAlgorithms
{
    static void Main()
    {
        int arraysLength = 100000;
        IComparable[] result = null;

        int[] intNumbers = { 5, 16, 3, 18, 54, 71, 2, 64, 55, 91, 0, 6, 85 };
        int[] sortedIntNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        int[] reversedIntNumbers = { 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

        double[] doubleNumbers = { 5, 16, 3, 18, 54, 71, 2, 64, 55, 91, 0, 6, 85 };
        double[] sortedDoubleNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        double[] reversedDoubleNumbers = { 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

        string[] stringArray = { "5", "16", "3", "18", "54", "71", "2", "64", "55", "91", "0", "6", "85" };
        string[] sortedStringArray = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" };
        string[] reversedStringArray = { "13", "12", "11", "10", "9", "8", "7", "6", "5", "4", "3", "2", "1" };

        Console.Write("insertion sort of random ints: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[intNumbers.Length];
                Array.Copy(intNumbers, result, intNumbers.Length);
                SortingAlgorithms.InsertionSort(result);
            }
        });

        Console.Write("selection sort of random ints: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[intNumbers.Length];
                Array.Copy(intNumbers, result, intNumbers.Length);
                SortingAlgorithms.SelectionSort(result);
            }
        });

        Console.Write("quick sort of random ints: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[intNumbers.Length];
                Array.Copy(intNumbers, result, intNumbers.Length);
                SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
            }
        });

        Console.Write("\ninsertion sort of random doubles: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[doubleNumbers.Length];
                Array.Copy(doubleNumbers, result, doubleNumbers.Length);
                SortingAlgorithms.InsertionSort(result);
            }
        });

        Console.Write("selection sort of random doubles: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[doubleNumbers.Length];
                Array.Copy(doubleNumbers, result, doubleNumbers.Length);
                SortingAlgorithms.SelectionSort(result);
            }
        });

        Console.Write("quick sort of random doubles: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[doubleNumbers.Length];
                Array.Copy(doubleNumbers, result, doubleNumbers.Length);
                SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
            }
        });

        Console.Write("\ninsertion sort of random strings: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[stringArray.Length];
                Array.Copy(stringArray, result, stringArray.Length);
                SortingAlgorithms.InsertionSort(result);
            }
        });

        Console.Write("selection sort of random strings: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[stringArray.Length];
                Array.Copy(stringArray, result, stringArray.Length);
                SortingAlgorithms.SelectionSort(result);
            }
        });

        Console.Write("quick sort of random strings: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[stringArray.Length];
                Array.Copy(stringArray, result, stringArray.Length);
                SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
            }
        });

        Console.Write("\ninsertion sort of sorted ints: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[sortedIntNumbers.Length];
                Array.Copy(sortedIntNumbers, result, sortedIntNumbers.Length);
                SortingAlgorithms.InsertionSort(result);
            }
        });

        Console.Write("selection sort of sorted ints: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[sortedIntNumbers.Length];
                Array.Copy(sortedIntNumbers, result, sortedIntNumbers.Length);
                SortingAlgorithms.SelectionSort(result);
            }
        });

        Console.Write("quick sort of sorted ints: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[sortedIntNumbers.Length];
                Array.Copy(sortedIntNumbers, result, sortedIntNumbers.Length);
                SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
            }
        });

        Console.Write("\ninsertion sort of sorted doubles: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[sortedDoubleNumbers.Length];
                Array.Copy(sortedDoubleNumbers, result, sortedDoubleNumbers.Length);
                SortingAlgorithms.InsertionSort(result);
            }
        });

        Console.Write("selection sort of sorted doubles: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[sortedDoubleNumbers.Length];
                Array.Copy(sortedDoubleNumbers, result, sortedDoubleNumbers.Length);
                SortingAlgorithms.SelectionSort(result);
            }
        });

        Console.Write("quick sort of sorted doubles: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[sortedDoubleNumbers.Length];
                Array.Copy(sortedDoubleNumbers, result, sortedDoubleNumbers.Length);
                SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
            }
        });

        Console.Write("\ninsertion sort of sorted strings: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[sortedStringArray.Length];
                Array.Copy(sortedStringArray, result, sortedStringArray.Length);
                SortingAlgorithms.InsertionSort(result);
            }
        });

        Console.Write("selection sort of sorted strings: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[sortedStringArray.Length];
                Array.Copy(sortedStringArray, result, sortedStringArray.Length);
                SortingAlgorithms.SelectionSort(result);
            }
        });

        Console.Write("quick sort of sorted strings: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[sortedStringArray.Length];
                Array.Copy(sortedStringArray, result, sortedStringArray.Length);
                SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
            }
        });

        Console.Write("\ninsertion sort of reversed ints: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[reversedIntNumbers.Length];
                Array.Copy(reversedIntNumbers, result, reversedIntNumbers.Length);
                SortingAlgorithms.InsertionSort(result);
            }
        });

        Console.Write("selection sort of reversed ints: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[reversedIntNumbers.Length];
                Array.Copy(reversedIntNumbers, result, reversedIntNumbers.Length);
                SortingAlgorithms.SelectionSort(result);
            }
        });

        Console.Write("quick sort of reversed ints: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[reversedIntNumbers.Length];
                Array.Copy(reversedIntNumbers, result, reversedIntNumbers.Length);
                SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
            }
        });

        Console.Write("\ninsertion sort of reversed doubles: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[reversedDoubleNumbers.Length];
                Array.Copy(reversedDoubleNumbers, result, reversedDoubleNumbers.Length);
                SortingAlgorithms.InsertionSort(result);
            }
        });

        Console.Write("selection sort of reversed doubles: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[reversedDoubleNumbers.Length];
                Array.Copy(reversedDoubleNumbers, result, reversedDoubleNumbers.Length);
                SortingAlgorithms.SelectionSort(result);
            }
        });

        Console.Write("quick sort of reversed doubles: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[reversedDoubleNumbers.Length];
                Array.Copy(reversedDoubleNumbers, result, reversedDoubleNumbers.Length);
                SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
            }
        });

        Console.Write("\ninsertion sort of reversed strings: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[reversedStringArray.Length];
                Array.Copy(reversedStringArray, result, reversedStringArray.Length);
                SortingAlgorithms.InsertionSort(result);
            }
        });

        Console.Write("selection sort of reversed strings: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[reversedStringArray.Length];
                Array.Copy(reversedStringArray, result, reversedStringArray.Length);
                SortingAlgorithms.SelectionSort(result);
            }
        });

        Console.Write("quick sort of reversed strings: ");
        DisplayExecutionTime(
        () =>
        {
            for (int i = 0; i < arraysLength; i++)
            {
                result = new IComparable[reversedStringArray.Length];
                Array.Copy(reversedStringArray, result, reversedStringArray.Length);
                SortingAlgorithms.Quicksort(result, 0, result.Length - 1);
            }
        });
    }

    static void DisplayExecutionTime(Action action)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        action();
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed);
    }
}