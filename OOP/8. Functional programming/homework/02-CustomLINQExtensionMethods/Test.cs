using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Test
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        numbers.Add(2);
        numbers.Add(3);
        numbers.Add(4);
        numbers.Add(5);
        numbers.Add(6);

        var result = numbers.WhereNot(x => x % 3 == 0);

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }


        Console.WriteLine();

        
        var allNumbers = numbers.Repeat(3);

        foreach (var item in allNumbers)
        {
            Console.WriteLine(item);
        }


        Console.WriteLine();


        List<string> words = new List<string>() { "Configuration", "hi", "cool", "full", "Hello", "how", "revolution", "commendation", "contrition", " starvation" };
        List<string> suffixes = new List<string>() { "tion", "l" };
        var filtredWords = words.WhereEndsWith(suffixes);

        foreach (var item in filtredWords)
        {
            Console.WriteLine(item);
        }
    }
}