using System;
using System.Collections;
using System.Collections.Generic;

public class OrderedSetNode<T> : IEnumerable<T> where T : IComparable<T>
{
    private OrderedSetNode<T> leftNode;
    private OrderedSetNode<T> rightNode;

    public OrderedSetNode(T value)
    {
        this.Value = value;
    }

    public OrderedSetNode<T> LeftNode
    {
        get { return this.leftNode; }
        set { this.leftNode = value; }
    }

    public OrderedSetNode<T> RightNode
    {
        get { return this.rightNode; }
        set { this.rightNode = value; }
    }

    public T Value
    {
        get;
        set;
    }

    public int Height
    {
        get
        {
            if (this.LeftNode == null && this.RightNode == null)
            {
                return 1;
            }
            else if (this.LeftNode == null)
            {
                return this.RightNode.Height + 1;
            }
            else if (this.RightNode == null)
            {
                return this.LeftNode.Height + 1;
            }
            else
            {
                return Math.Max(this.LeftNode.Height, this.RightNode.Height) + 1;
            }
        }
    }

    public int Balance
    {
        get
        {
            if (this.LeftNode == null && this.RightNode == null)
            {
                return 0;
            }
            else if (this.LeftNode == null)
            {
                return -this.RightNode.Height;
            }
            else if (this.RightNode == null)
            {
                return this.LeftNode.Height;
            }
            else
            {
                return this.LeftNode.Height - this.RightNode.Height;
            }
        }
    }

    public void Add(T element)
    {
        if (this.Value.CompareTo(element) < 0)
        {
            if (this.RightNode == null)
            {
                this.RightNode = new OrderedSetNode<T>(element);
            }
            else
            {
                this.RightNode.Add(element);
            }
        }
        else if (this.Value.CompareTo(element) > 0)
        {
            if (this.LeftNode == null)
            {
                this.LeftNode = new OrderedSetNode<T>(element);
            }
            else
            {
                this.LeftNode.Add(element);
            }
        }

        CheckBalance();
    }

    public bool Contains(T element)
    {
        if (this.Value.CompareTo(element) == 0)
        {
            return true;
        }
        else if (this.Value.CompareTo(element) < 0)
        {
            if (this.RightNode == null)
            {
                return false;
            }
            else
            {
                return this.RightNode.Contains(element);
            }
        }
        else
        {
            if (this.LeftNode == null)
            {
                return false;
            }
            else
            {
                return this.LeftNode.Contains(element);
            }
        }
    }
    
    public bool Remove(T element)
    {
        if (this.Value.CompareTo(element) < 0)
        {
            bool result = HandleRemovingNode(ref this.rightNode, element);

            if (result)
            {
                this.CheckBalance();
            }

            return result;
        }
        else if (this.Value.CompareTo(element) > 0)
        {
            bool result = HandleRemovingNode(ref this.leftNode, element);

            if (result)
            {
                this.CheckBalance();
            }

            return result;
        }
        else
        {
            throw new InvalidOperationException("A node cannot self-remove itself.");
        }
    }

    public OrderedSetNode<T> FindReplacingNode()
    {
        if (this.LeftNode == null)
        {
            throw new InvalidOperationException("A node cannot replace itself.");
        }

        if (this.LeftNode.LeftNode != null)
        {
            return this.LeftNode.FindReplacingNode();
        }
        else
        {
            var leftNode = this.LeftNode;
            this.LeftNode = null;

            return leftNode;
        }
    }

    public static void BalanceNode(ref OrderedSetNode<T> node, int balance)
    {
        if (balance < 0)
        {
            if (node.RightNode.Balance < 0)
            {
                OrderedSetNode<T> root = node.PerformLeftRotation();
                node = root;
            }
            else
            {
                OrderedSetNode<T> rightSubtreeRoot = node.RightNode.PerformRightRotation();
                node.RightNode = rightSubtreeRoot;

                OrderedSetNode<T> root = node.PerformLeftRotation();
                node = root;
            }
        }
        else
        {
            if (node.LeftNode.Balance < 0)
            {
                OrderedSetNode<T> leftSubtreeRoot = node.LeftNode.PerformLeftRotation();
                node.LeftNode = leftSubtreeRoot;

                OrderedSetNode<T> root = node.PerformRightRotation();
                node = root;
            }
            else
            {
                OrderedSetNode<T> root = node.PerformRightRotation();
                node = root;
            }
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (this.LeftNode != null)
        {
            foreach (var element in this.LeftNode)
            {
                yield return element;
            }
        }

        yield return this.Value;

        if (this.RightNode != null)
        {
            foreach (var element in this.RightNode)
            {
                yield return element;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private OrderedSetNode<T> PerformLeftRotation()
    {
        OrderedSetNode<T> root = this.RightNode;
        this.RightNode = root.LeftNode;
        root.LeftNode = this;

        return root;
    }

    private OrderedSetNode<T> PerformRightRotation()
    {
        OrderedSetNode<T> root = this.LeftNode;
        this.LeftNode = root.RightNode;
        root.RightNode = this;

        return root;
    }

    private static bool HandleRemovingNode(ref OrderedSetNode<T> node, T element)
    {
        if (node == null)
        {
            return false;
        }

        if (node.Value.CompareTo(element) == 0)
        {
            if (node.RightNode == null)
            {
                node = node.LeftNode;
                return true;
            }

            OrderedSetNode<T> replaceNode;
            if (node.RightNode.LeftNode == null)
            {
                node.RightNode.LeftNode = node.LeftNode;
                node = node.RightNode;
                return true;
            }

            replaceNode = node.RightNode.FindReplacingNode();
            node.Value = replaceNode.Value;

            return true;
        }
        else
        {
            return node.Remove(element);
        }
    }

    private void CheckBalance()
    {
        if (this.LeftNode != null)
        {
            int leftBalance = this.LeftNode.Balance;

            if (Math.Abs(leftBalance) > 1)
            {
                BalanceNode(ref this.leftNode, leftBalance);
            }
        }

        if (this.RightNode != null)
        {
            int rightBalance = this.RightNode.Balance;

            if (Math.Abs(rightBalance) > 1)
            {
                BalanceNode(ref this.rightNode, rightBalance);
            }
        }
    }
}