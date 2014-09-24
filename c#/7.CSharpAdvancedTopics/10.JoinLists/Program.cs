using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] firstNumbers = Console.ReadLine().Split();
        string[] secondNumbers = Console.ReadLine().Split();

        List<int> firstList = new List<int>();
        List<int> secondList = new List<int>();

        foreach (string number in firstNumbers)
        {
            firstList.Add(Convert.ToInt32(number));
        }

        foreach (string number in secondNumbers)
        {
            secondList.Add(Convert.ToInt32(number));
        }

        for (int i = 0; i < firstList.Count; i++)
        {
            if (i != firstList.Count - 1)
            {
                if (firstList[i] == firstList[i + 1])
                {
                    firstList.RemoveAt(i);
                }
            }
        }

        for (int i = 0; i < secondList.Count; i++)
        {
            if(!numberExist(secondList[i], firstList))
            {
                firstList.Add(secondList[i]);
            }
        }

        firstList.Sort();

        foreach (int number in firstList)
        {
            Console.Write("{0} ", number);
        }

        Console.WriteLine();
    }

    static bool numberExist(int number, List<int> list)
    {
        bool exist = false;

        foreach (int num in list)
        {
            if (num == number)
            {
                exist = true;
            }
        }

        return exist;
    }
}