using System;

public class GenericList<T>
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
    /*
    public T Find(T value)
    {
        bool found = false;

        for (int i = 0; i < this.Count; i++)
        {
            if(value == this.elements[i]) {
                
            }
        }

        T result = elements[index];
        return result;
    }*/

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
}
