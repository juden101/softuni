using System;

class Program
{
    static void Main()
    {
        GenericList<int> list = new GenericList<int>();

        try
        {
            //adding an element 
            list.Add(1);
            list.Add(2);
            list.Add(3);

            //accessing element by index
            Console.WriteLine(list.Get(2));

            //removing element by index
            list.Remove(1);

            //inserting element at given position
            list.Insert(1, 17);

            //clearing the list
            //list.Clear();

            //finding element index by given value
            Console.WriteLine(list.Find(3));

            //checking if the list contains a value
            Console.WriteLine(list.Contains(1));

            //maximum element
            Console.WriteLine(list.Max());

            //minimum element
            Console.WriteLine(list.Min());

            //printing the entire list (override ToString())
            Console.WriteLine(list);

            //version
            Type type = typeof(GenericList<>);
            object[] allAttributes = type.GetCustomAttributes(typeof(VersionAttribute), false);
            Console.WriteLine("GenericsList's version is {0}", ((VersionAttribute)allAttributes[0]).Version);
        }
        catch (IndexOutOfRangeException exc)
        {
            Console.WriteLine(exc.Message);
        }
        catch(InvalidOperationException exc)
        {
            Console.WriteLine(exc.Message);
        }
    }
}