using System;

class Program
{
    static void Main()
    {
        GenericList<int> list = new GenericList<int>();

        //adding an element 
        list.Add(1);
        list.Add(2);
        list.Add(3);

        //accessing element by index
        //Console.WriteLine(list.Get(2));

        //removing element by index
        //list.Remove(1);

        //inserting element at given position
        //list.Insert(2, 17);

        //clearing the list
        //list.Clear();

        //finding element index by given value
        //Console.WriteLine(list.Find(3));

        Console.WriteLine("Number of elements: {0}", list.Count);

        for (int i = 0; i < list.Count; i++)
        {
            int element = list[i];
            Console.WriteLine(element);
        }
    }
}