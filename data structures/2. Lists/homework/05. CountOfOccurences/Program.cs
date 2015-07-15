using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        string[] numbers = inputLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<int, int> occurences = new Dictionary<int, int>();

        occurences = RemoveOddOccurences.GetOccurences(numbers);

        foreach (var key in occurences.Keys)
        {
            if (occurences[key] == 1)
            {
                Console.WriteLine("{0} -> {1} time", key, occurences[key]);
            }
            else
            {
                Console.WriteLine("{0} -> {1} times", key, occurences[key]);
            }
        }
    }
}