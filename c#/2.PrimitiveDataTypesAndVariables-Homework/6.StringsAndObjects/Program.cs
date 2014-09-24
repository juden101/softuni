using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsAndObjects
{
    class Program
    {
        static void Main()
        {
            string firstWord = "Hello";
            string secondWord = "World";

            object sentance = firstWord + " " + secondWord;

            string finalWord = sentance.ToString();

            Console.WriteLine(sentance);
        }
    }
}
