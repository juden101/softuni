using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sunglasses
{
    class Program
    {
        static void Main()
        {
            int glassesHeight = int.Parse(Console.ReadLine());

            for (int i = 0; i < glassesHeight; i++)
            {
                if(i == 0 || i == glassesHeight - 1)
                {
                    Console.WriteLine("{0}{1}{0}", new string('*', glassesHeight * 2), new string(' ', glassesHeight));
                }
                else if (i == glassesHeight / 2)
                {
                    Console.WriteLine("{0}{1}{0}{2}{0}{1}{0}", new string('*', 1), new string('/', glassesHeight * 2 - 2), new string('|', glassesHeight));
                }
                else
                {
                    Console.WriteLine("{0}{1}{0}{2}{0}{1}{0}", new string('*', 1), new string('/', glassesHeight * 2 - 2), new string(' ', glassesHeight));
                }
            }
        }
    }
}
