using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsoscelesTriangle
{
    class Program
    {
        static void Main()
        {
            char copyrightCharacter = '\u00A9';

            Console.WriteLine("   " + copyrightCharacter);
            Console.WriteLine("  " + copyrightCharacter + " " + copyrightCharacter);
            Console.WriteLine(" " + copyrightCharacter + "   " + copyrightCharacter);
            Console.WriteLine(copyrightCharacter + " " + copyrightCharacter + " " + copyrightCharacter + " " + copyrightCharacter);
        }
    }
}
