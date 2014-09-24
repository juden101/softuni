using System;

class Program
{
    static void Main()
    {
        string number;
        string result = "not a digit";
        int d;

        Console.Write("d = ");
        number = Console.ReadLine();

        if (int.TryParse(number, out d))
        {
            if (d >= 0 && d <= 9)
            {
                if (d == 0)
                {
                    result = "zero";
                }
                else if (d == 1)
                {
                    result = "one";
                }
                else if (d == 2)
                {
                    result = "two";
                }
                else if (d == 3)
                {
                    result = "three";
                }
                else if (d == 4)
                {
                    result = "four";
                }
                else if (d == 5)
                {
                    result = "five";
                }
                else if (d == 6)
                {
                    result = "six";
                }
                else if (d == 7)
                {
                    result = "seven";
                }
                else if (d == 8)
                {
                    result = "eight";
                }
                else if (d == 9)
                {
                    result = "nine";
                }
            }
        }

        Console.WriteLine("result: {0}", result);
    }
}