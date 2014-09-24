using System;
using System.Threading;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char[] chars = { 's', 'n', 'k', 'p' };
        List<string> foundCombinations = new List<string>();


        for (int a = 0; a < 4; a++)
        {
            for (int b = 0; b < 4; b++)
            {
                for (int c = 0; c < 4; c++)
                {
                    for (int d = 0; d < 4; d++)
                    {
                        for (int e = 0; e < 4; e++)
                        {
                            for (int f = 0; f < 4; f++)
                            {
                                for (int g = 0; g <4; g++)
                                {
                                    for (int h = 0; h < 4; h++)
                                    {
                                        int firstPart = Weight(chars[a]) + Weight(chars[b]) + Weight(chars[c]) + Weight(chars[d]);
                                        int secondPart = Weight(chars[e]) + Weight(chars[f]) + Weight(chars[g]) + Weight(chars[h]);
                                        
                                        if(firstPart - secondPart == n || secondPart - firstPart == n)
                                        {
                                            string currentCombination = chars[a].ToString() + chars[b] + chars[c] + chars[d] + chars[e] + chars[f] + chars[g] + chars[h];

                                            foundCombinations.Add(currentCombination);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        if(foundCombinations.Count > 0)
        {
            foundCombinations.Sort();

            foreach (string combination in foundCombinations)
            {
                Console.WriteLine(combination);
            }
        }
        else
        {
            Console.WriteLine("No");
        }
    }

    static int Weight(char c)
    {
        if(c == 's')
        {
            return 3;
        }

        if (c == 'n')
        {
            return 4;
        }

        if (c == 'k')
        {
            return 1;
        }

        if (c == 'p')
        {
            return 5;
        }

        return 0;
    }
}