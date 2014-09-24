using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesInStrings
{
    class Program
    {
        static void Main()
        {
            string firstQuotesInString = "The \"use\" of quotations causes difficulties.";
            string secondQuotesInString = @"The ""use"" of quotations causes difficulties.";

            Console.WriteLine(firstQuotesInString);
            Console.WriteLine(secondQuotesInString);
        }
    }
}
