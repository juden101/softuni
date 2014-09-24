using System;
using System.Collections.Generic;

class Program
{
    static List<Elements> elements = new List<Elements>();

    struct Elements
    {
        public string elementsName;
        public int elementsLength;

        public Elements(string name, int length)
        {
            elementsName = name;
            elementsLength = length;
        }
    }

    static void Main()
    {
        int n;

        n = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < n; i++)
        {
            string elementName = Console.ReadLine();

            if(elements.Count == 0)
            {
                elements.Add(new Elements(elementName, 1));
            }
            else
            {
                OperateElement(elementName);
            }
        }

        Console.WriteLine();

        int maxFound = 0;
        string name = "";

        foreach (Elements element in elements)
        {
            if (element.elementsLength > maxFound)
            {
                maxFound = element.elementsLength;
                name = element.elementsName;
            }
        }

        Console.WriteLine(maxFound);
        for (int i = 0; i < maxFound; i++)
        {
            Console.WriteLine(name);
        }
    }

    static void OperateElement(string name)
    {
        bool foundElement = false;

        for (int i = 0; i < elements.Count; i++)
        {
            if(elements[i].elementsName == name)
            {
                foundElement = true;
                elements[i] = new Elements(name, elements[i].elementsLength + 1);
            }
        }

        if(!foundElement)
        {
            elements.Add(new Elements(name, 1));
        }
    }
}