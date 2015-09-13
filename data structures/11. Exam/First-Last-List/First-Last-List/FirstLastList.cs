using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    private List<T> elements = new List<T>();
    private OrderedBag<T> orderedElements = new OrderedBag<T>((e1, e2) => e1.CompareTo(e2));
    private OrderedBag<T> orderedElementsDesc = new OrderedBag<T>((e1, e2) => e2.CompareTo(e1));

    public void Add(T newElement)
    {
        this.elements.Add(newElement);

        orderedElements.Add(newElement);
        orderedElementsDesc.Add(newElement);
    }

    public int Count
    {
        get
        {
            return this.elements.Count;
        }
    }

    public IEnumerable<T> First(int count)
    {
        if (this.elements.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.elements.Take(count);
    }

    public IEnumerable<T> Last(int count)
    {
        if (this.elements.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.elements.Skip(Math.Max(0, this.elements.Count - count)).Reverse();
    }

    public IEnumerable<T> Min(int count)
    {
        if (this.elements.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.orderedElements.Take(count);
    }

    public IEnumerable<T> Max(int count)
    {
        if (this.elements.Count < count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.orderedElementsDesc.Take(count);
    }

    public int RemoveAll(T element)
    {
        this.orderedElements.RemoveAllCopies(element);
        this.orderedElementsDesc.RemoveAllCopies(element);

        return this.elements.RemoveAll(e => e.CompareTo(element) == 0);
    }

    public void Clear()
    {
        this.elements.Clear();
        this.orderedElements.Clear();
        this.orderedElementsDesc.Clear();
    }
}
