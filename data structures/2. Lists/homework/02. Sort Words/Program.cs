using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SortWords
{
    static void Main()
    {
        string input = Console.ReadLine();
        List<string> words = input.Split(' ').ToList();

        words.Sort();

        string sortedOutput = String.Join(" ", words);

        Console.WriteLine(sortedOutput);
    }
}