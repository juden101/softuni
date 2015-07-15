using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RemoveOddOccurences
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        string[] numbers = inputLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<int, int> allOccurences = new Dictionary<int, int>();

        allOccurences = GetOccurences(numbers);

        StringBuilder sb = new StringBuilder();
        foreach (int key in allOccurences.Keys)
        {
            if (allOccurences[key] % 2 != 0)
            {
                continue;
            }

            for (int i = 0; i < allOccurences[key]; i++)
            {
                sb.Append(key);
                sb.Append(" ");
            }
        }

        Console.WriteLine(sb.ToString());
    }

    public static Dictionary<int, int> GetOccurences(string[] inputArr)
    {
        Dictionary<int, int> occurences = new Dictionary<int, int>();

        foreach (string numberStr in inputArr)
        {
            int number = int.Parse(numberStr);

            if (occurences.ContainsKey(number))
            {
                occurences[number]++;
            }
            else
            {
                occurences[number] = 1;
            }

        }

        return occurences;
    }
}