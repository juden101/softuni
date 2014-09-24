using System;

class Program
{
    static void Main()
    {
        string n = Console.ReadLine().Trim();
        bool foundSolution = false;
        int nSum = 0;

        foreach (char number in n.ToCharArray())
        {
            nSum += Convert.ToInt32(number.ToString());
        }

        for (int i1 = 0; i1 < 6; i1++)
        {
            for (int i2 = 0; i2 < 6; i2++)
            {
                for (int i3 = 0; i3 < 6; i3++)
                {
                    for (int i4 = 0; i4 < 6; i4++)
                    {
                        for (int i5 = 0; i5 < 6; i5++)
                        {
                            for (int i6 = 0; i6 < 6; i6++)
                            {
                                if(i1 * i2 * i3 * i4 * i5 * i6 == nSum)
                                {
                                    foundSolution = true;

                                    Console.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|", MorseCode(i1), MorseCode(i2), MorseCode(i3), MorseCode(i4), MorseCode(i5), MorseCode(i6));
                                }
                            }
                        }
                    }
                }
            }
        }

        if(!foundSolution)
        {
            Console.WriteLine("No");
        }
    }

    static string MorseCode(int n)
    {
        string code = "";

        if(n == 0)
        {
            code = "-----";
        }
        else if (n == 1)
        {
            code = ".----";
        }
        else if (n == 2)
        {
            code = "..---";
        }
        else if (n == 3)
        {
            code = "...--";
        }
        else if (n == 4)
        {
            code = "....-";
        }
        else if (n == 5)
        {
            code = ".....";
        }

        return code;
    }
}