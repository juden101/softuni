using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Name> names = new List<Name>();

    struct Name
    {
        public string n;
        public int l;

        public Name(string name, int length)
        {
            n = name;
            l = length;
        }
    }

    static void Main()
    {
        string[] stringNames = Console.ReadLine().Split();

        for (int i = 0; i < stringNames.Length; i++)
        {
            string currentName = stringNames[i];

            if (names.Count == 0)
            {
                names.Add(new Name(currentName, 1));
            }
            else
            {
                OperateElement(currentName);
            }
        }

        names = names.OrderBy(x => x.n).ToList();

        foreach (Name currentName in names)
        {
            Console.WriteLine("{0} -> {1}", currentName.n, currentName.l);
        }
    }

    static void OperateElement(string name)
    {
        bool foundName = false;

        for (int i = 0; i < names.Count; i++)
        {
            if (names[i].n == name)
            {
                foundName = true;
                names[i] = new Name(name, names[i].l + 1);
            }
        }

        if (!foundName)
        {
            names.Add(new Name(name, 1));
        }
    }
}