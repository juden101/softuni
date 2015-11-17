﻿using System;

public class CircularQueue<T>
{
    private T[] elements;
    private int startIndex = 0;
    private int endIndex = 0;

    private const int InitialCapacity = 16;

    public int Count { get; private set; }

    public CircularQueue(int capacity = InitialCapacity)
    {
        this.elements = new T[capacity];
    }

    public void Enqueue(T element)
    {
        if (this.Count >= this.elements.Length)
        {
            this.Grow();
        }

        this.elements[this.endIndex] = element;
        this.endIndex = (this.endIndex + 1) % this.elements.Length;
        this.Count++;
    }

    private void Grow()
    {
        var newElements = new T[2 * this.elements.Length];

        this.CopyAllElementsTo(newElements);

        this.elements = newElements;
        this.startIndex = 0;
        this.endIndex = this.Count;
    }

    private void CopyAllElementsTo(T[] resultArr)
    {
        int sourceIndex = this.startIndex;

        for (int i = 0; i < this.Count; i++)
        {
            resultArr[i] = this.elements[sourceIndex];
            sourceIndex = (sourceIndex + 1) % this.elements.Length;
        }
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty!");
        }

        var result = this.elements[startIndex];
        this.startIndex = (this.startIndex + 1) % this.elements.Length;
        this.Count--;

        return result;
    }

    public T[] ToArray()
    {
        var resultArr = new T[this.Count];
        CopyAllElementsTo(resultArr);

        return resultArr;
    }
}