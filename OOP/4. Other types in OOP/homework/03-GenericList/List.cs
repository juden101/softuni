using System;
using System.Text;

[Version(1.234)]
public class GenericList<T> where T : IComparable<T>
{
    const int DefaultCapacity = 16;

    private T[] elements;
    private int count = 0;

    public GenericList(int capacity = DefaultCapacity)
    {
        elements = new T[capacity];
    }

    public int Count
    {
        get
        {
            return this.count;
        }
        set
        {
            this.count = value;
        }
    }

    public void Add(T element)
    {
        if (count >= elements.Length)
        {
            T[] tempElements = this.elements;
            this.elements = new T[this.elements.Length * 2];

            for(int i = 0; i < tempElements.Length; i++) {
                this.elements[i] = tempElements[i];
            }
        }

        this.elements[count] = element;
        count++;
    }

    public T Get(int index)
    {
        this.CheckIndex(index);

        T result = elements[index];
        return result;
    }

    public void Remove(int index)
    {
        this.CheckIndex(index);

        T[] tempElements = new T[this.elements.Length - 1];
        
        for (int i = 0, c = 0; i < this.elements.Length; i++)
        {
            if(i == index) {
                continue;
            }

            tempElements[c] = this.elements[i];
            c++;
        }

        this.elements = tempElements;
        this.Count--;
    }

    public void Insert(int index, T element)
    {
        this.CheckIndex(index);

        T[] tempElements = new T[this.Count + 1];

        for (int i = 0; i < this.Count + 1; i++)
        {
            if(i == index) {
                tempElements[i] = element;
            }
            else if(i < index) {
                tempElements[i] = this.elements[i];
            }
            else
            {
                tempElements[i] = this.elements[i - 1];
            }
        }

        this.elements = tempElements;
        this.Count++;
    }

    public void Clear()
    {
        elements = new T[DefaultCapacity];
        this.Count = 0;
    }
    
    public int Find(T value)
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (Equals(value, this.elements[i]))
            {
                return i;
            }
        }

        return -1;
    }

    public bool Contains(T value)
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (Equals(value, this.elements[i]))
            {
                return true;
            }
        }

        return false;
    }

    public static bool Equal<T>(T first, T second) where T : IComparable<T>
    {
        if (first.CompareTo(second) == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public T Max()
    {
        if (this.count == 0)
        {
            throw new InvalidOperationException("The list is empty");
        }

        T maxValue = this.elements[0];
        for (int i = 0; i < this.Count; i++)
        {
            if (this.elements[i].CompareTo(maxValue) > 0)
            {
                maxValue = this.elements[i];
            }
        }

        return maxValue;
    }
    
    public T Min()
    {
        if (this.count < 1)
        {
            throw new InvalidOperationException("The list is empty");
        }

        T min = this.elements[0];
        for (int i = 1; i < this.Count; i++)
        {
            if (this.elements[i].CompareTo(min) < 0)
            {
                min = elements[i];
            }
        }

        return min;
    }

    public static T[] CreateArray<T>(T value, int count)
    {
        T[] arr = new T[count];
        for (int i = 0; i < count; i++)
        {
            arr[i] = value;
        }
        return arr;
    }

    public static T Max<T>(T first, T second) where T : IComparable<T>
    {
        if (first.CompareTo(second) >= 0)
        {
            return first;
        }
        else
        {
            return second;
        }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            }

            T result = elements[index];
            return result;
        }
    }

    public void CheckIndex(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
        }
    }

    public override string ToString()
    {
        string output = "";

        for (int i = 0; i < this.Count; i++)
        {
            output += this.elements[i];

            if (i < this.Count - 1)
            {
                output += ", ";
            }
        }

        return String.Format("[{0}]", output);
    }
}
