using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIITable
{
    class Program
    {
        static void Main()
        {
            for (int i = 0; i < 255; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
