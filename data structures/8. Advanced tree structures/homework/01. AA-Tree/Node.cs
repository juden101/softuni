using System;

public class Node<T> where T : IComparable<T>
{
    public Node<T> left;
    public Node<T> right;
    public int level;
    public T value;

    public Node()
    {
        this.level = 0;
        this.left = this;
        this.right = this;
    }

    public Node(T value, Node<T> sentinel)
    {
        this.value = value;
        this.level = 1;
        this.left = sentinel;
        this.right = sentinel;
    }

    public void Print(string indent)
    {
        if (this.left.level != 0)
        {
            this.left.Print(indent + "   ");
        }

        Console.WriteLine(indent + this.value);

        if (this.right.level != 0)
        {
            this.right.Print(indent + "   ");
        }
    }
}