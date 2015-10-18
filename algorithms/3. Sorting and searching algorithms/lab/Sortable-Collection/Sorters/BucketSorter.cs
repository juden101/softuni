namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Sortable_Collection.Contracts;
    using Sorters;

    public class BucketSorter : ISorter<int>
    {
        public double Max { get; set; }

        public void Sort(List<int> collection)
        {
            var buckets = new List<int>[collection.Count];

            foreach (var element in collection)
            {
                int bucketIndex = (int)(element / this.Max * collection.Count);

                if (buckets[bucketIndex] == null)
                {
                    buckets[bucketIndex] = new List<int>();
                }

                buckets[bucketIndex].Add(element);
            }

            collection.Clear();
            var sorter = new Quicksorter<int>();

            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] == null)
                {
                    continue;
                }

                var bucketCollection = new SortableCollection<int>(buckets[i]);
                bucketCollection.Sort(sorter);
            }
            
            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] != null)
                {
                    buckets[i].Sort();
                    collection.AddRange(buckets[i]);
                }
            }
        }
    }
}
