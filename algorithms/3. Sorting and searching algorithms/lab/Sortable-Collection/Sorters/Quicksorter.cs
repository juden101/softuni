namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.Quicksort(collection, 0, collection.Count - 1);
        }

        private void Quicksort(List<T> array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivotIndex = end;
            int stepIndex = start;

            for (int i = start; i < end; i++)
            {
                if (array[i].CompareTo(array[pivotIndex]) <= 0)
                {
                    T temp = array[i];
                    array[i] = array[stepIndex];
                    array[stepIndex] = temp;

                    stepIndex++;
                }
            }

            T tmp = array[stepIndex];
            array[stepIndex] = array[pivotIndex];
            array[pivotIndex] = tmp;

            this.Quicksort(array, start, stepIndex - 1);
            this.Quicksort(array, stepIndex + 1, end);
        }
    }
}