using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NineDigitMagicNumbers
{
    class Program
    {
        static void Main()
        {
            int sum = int.Parse(Console.ReadLine());
            int diff = int.Parse(Console.ReadLine());
            bool combinationFound = false;

            for (int a = 1; a < 8; a++)
            {
                for (int b = 1; b < 8; b++)
                {
                    for (int c = 1; c < 8; c++)
                    {
                        int abc = a * 100 + b * 10 + c;

                        for (int d = 1; d < 8; d++)
                        {
                            for (int e = 1; e < 8; e++)
                            {
                                for (int f = 1; f < 8; f++)
                                {
                                    int def = d * 100 + e * 10 + f;

                                    for (int g = 1; g < 8; g++)
                                    {
                                        for (int h = 1; h < 8; h++)
                                        {
                                            for (int i = 1; i < 8; i++)
                                            {
                                                int ghi = g * 100 + h * 10 + i;

                                                int digitSum = a+b+c+d+e+f+g+h+i;
                                                if (digitSum == sum && ghi - def == diff && def - abc == diff)
                                                {
                                                    Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}", a, b, c, d, e, f, g, h, i);
                                                    combinationFound = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (combinationFound == false)
            {
                Console.WriteLine("No");
            }
        }
    }
}
