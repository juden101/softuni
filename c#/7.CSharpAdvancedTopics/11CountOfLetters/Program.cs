using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Letter> letters = new List<Letter>();

    struct Letter
    {
        public string c;
        public int l;

        public Letter(string character, int length)
        {
            c = character;
            l = length;
        }
    }

    static void Main()
    {
        string[] letts = Console.ReadLine().Split();

        for (int i = 0; i < letts.Length; i++)
        {
            string currentLetter = letts[i];

            if (letters.Count == 0)
            {
                letters.Add(new Letter(currentLetter, 1));
            }
            else
            {
                OperateElement(currentLetter);
            }
        }

        letters = letters.OrderBy(x => x.c).ToList();

        foreach (Letter currentLetter in letters)
        {
            Console.WriteLine("{0} -> {1}", currentLetter.c, currentLetter.l);
        }
    }

    static void OperateElement(string letter)
    {
        bool foundLetter = false;

        for (int i = 0; i < letters.Count; i++)
        {
            if (letters[i].c == letter)
            {
                foundLetter = true;
                letters[i] = new Letter(letter, letters[i].l + 1);
            }
        }

        if (!foundLetter)
        {
            letters.Add(new Letter(letter, 1));
        }
    }
}