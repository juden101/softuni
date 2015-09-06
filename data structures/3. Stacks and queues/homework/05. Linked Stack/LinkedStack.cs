namespace StacksAndQueuesHomework
{
    using System;

    public class LinkedStack<T>
    {
        private Node<T> firstNode;

        public int Count
        {
            get;
            private set;
        }

        public LinkedStack()
        {
            this.firstNode = null;
            this.Count = 0;
        }

        public void Push(T element)
        {
            Node<T> currentNode = new Node<T>(element, this.firstNode);
            this.firstNode = currentNode;
            this.Count++;
        }

        public T Pop()
        {
            if (Object.ReferenceEquals(null, this.firstNode))
            {
                throw new IndexOutOfRangeException();
            }

            Node<T> popedElement = this.firstNode;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;

            return popedElement.Value;
        }

        public T[] ToArray()
        {
            T[] result = new T[this.Count];
            Node<T> currentNode = this.firstNode;

            for (int i = 0; i < this.Count; i++)
            {
                result[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return result;
        }

        private class Node<T>
        {
            private T value;

            public T Value
            {
                get;
                private set;
            }

            public Node<T> NextNode
            {
                get;
                set;
            }

            public Node(T value, Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }
        }
    }
}