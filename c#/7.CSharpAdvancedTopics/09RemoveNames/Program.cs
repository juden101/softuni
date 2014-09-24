using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] firstList = Console.ReadLine().Split();
        string[] secondList = Console.ReadLine().Split();

        foreach (string name in firstList)
        {
            if (!nameExist(name, secondList))
            {
                Console.Write(name + " ");
            }
        }

        Console.WriteLine();
    }

    static bool nameExist(string listName, string[] list)
    {
        bool exist = false;

        foreach (string name in list)
        {
            if(name == listName)
            {
                exist = true;
            }
        }

        return exist;
    }
}