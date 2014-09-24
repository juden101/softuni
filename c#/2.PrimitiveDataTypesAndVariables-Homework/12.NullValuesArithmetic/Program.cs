using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullValuesArithmetic
{
    class Program
    {
        static void Main()
        {
            int? intNumber = null;
            double? doubleNumber = null;

            Console.WriteLine("int number: {0} \ndouble number: {1}", intNumber + 1, doubleNumber + 3);
        }
    }
}
