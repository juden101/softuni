namespace StacksAndQueuesHomework
{
    using System;
    using System.Linq;

    public class ArrayStack<T>
    {
        private T[] elements;

        private const int InitialCapacity = 16;

        public int Count
        {
            get;
            private set;
        }

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
            this.Count = 0;
        }

        public void Push(T element)
        {
            this.elements[this.Count] = element;
            this.Count++;

            if (this.Count == this.elements.Length)
            {
                this.Grow();
            }
        }

        public T Pop()
        {
            this.Count--;

            return this.elements[this.Count];
        }

        public T[] ToArray()
        {
            T[] result = new T[this.Count];

            for (int i = this.Count - 1, j = 0; i >= 0; i--, j++)
            {
                result[j] = this.elements[i];
            }

            return result;
        }

        private void Grow()
        {
            var newElements = new T[this.elements.Length * 2];
            Array.Copy(this.elements, newElements, this.Count);
            this.elements = newElements;
        }
    }
}