namespace StacksAndQueuesHomework
{
    using System;

    public class LinkedQueue<T>
    {
        private QueueNode<T> headNode;
        private QueueNode<T> tailNode;

        public int Count
        {
            get;
            private set;
        }

        public LinkedQueue()
        {
            this.Count = 0;
            this.headNode = null;
            this.tailNode = null;
        }

        public void Enqueue(T element)
        {
            QueueNode<T> currentNode = new QueueNode<T>(element);

            if (this.Count == 0)
            {
                this.headNode = currentNode;
                this.tailNode = this.headNode;
            }
            else
            {
                currentNode.NextNode = this.headNode;
                this.headNode.PrevNode = currentNode;
                this.headNode = currentNode;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            T result = this.tailNode.Value;
            this.tailNode = this.tailNode.PrevNode;
            this.Count--;

            if (!Object.ReferenceEquals(null, this.tailNode))
            {
                this.tailNode.NextNode = null;
            }
            else
            {
                this.headNode = null;
            }

            return result;
        }

        public T[] ToArray()
        {
            T[] result = new T[this.Count];
            QueueNode<T> currentNode = this.tailNode;

            for (int i = 0; i < this.Count; i++)
            {
                result[i] = currentNode.Value;
                currentNode = currentNode.PrevNode;
            }

            return result;
        }

        private class QueueNode<T>
        {
            public T Value
            {
                get;
                private set;
            }

            public QueueNode<T> NextNode
            {
                get;
                set;
            }

            public QueueNode<T> PrevNode
            {
                get;
                set;
            }

            public QueueNode(T value)
            {
                this.Value = value;
                this.NextNode = null;
                this.PrevNode = null;
            }
        }
    }
}