namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; } = new List<T>();

        public int Count => this.Items.Count;

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            int start = 0;
            int end = this.Items.Count - 1;

            while (start <= end)
            {
                int mid = (end + start) / 2;

                if (this.Items[mid].CompareTo(item) == 0)
                {
                    return mid;
                }

                if (item.CompareTo(this.Items[mid]) > 0)
                {
                    start = mid + 1;
                }

                if (item.CompareTo(this.Items[mid]) < 0)
                {
                    end = mid - 1;
                }
            }

            return -1;
        }

        public int InterpolationSearch(T item)
        {
            throw new NotImplementedException();
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.Items)}]";
        }
    }
}