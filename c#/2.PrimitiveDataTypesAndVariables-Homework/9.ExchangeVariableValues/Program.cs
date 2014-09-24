using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeVariableValues
{
    class Program
    {
        static void Main()
        {
            int a = 5;
            int b = 10;
            int c;

            c = a;
            a = b;
            b = c;

            Console.WriteLine("a: {0}, b: {1}", a, b);
        }
    }
}
