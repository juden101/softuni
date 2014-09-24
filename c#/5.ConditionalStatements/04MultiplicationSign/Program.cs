using System;

class Program
{
    static void Main()
    {
        double a, b, c;
        char result = '0';

        Console.Write("a = ");
        a = double.Parse(Console.ReadLine());

        Console.Write("b = ");
        b = double.Parse(Console.ReadLine());

        Console.Write("c = ");
        c = double.Parse(Console.ReadLine());

        if(a > 0)
        {
            if(b > 0)
            {
                if(c > 0)
                {
                    result = '+';
                }
                else if(c < 0)
                {
                    result = '-';
                }
            }
            else if(b < 0)
            {
                if(c > 0)
                {
                    result = '-';
                }
                else if (c < 0)
                {
                    result = '+';
                }
            }
        }
        else if(a < 0)
        {
            if (b > 0)
            {
                if (c > 0)
                {
                    result = '-';
                }
                else if (c < 0)
                {
                    result = '+';
                }
            }
            else if (b < 0)
            {
                if (c > 0)
                {
                    result = '+';
                }
                else if (c < 0)
                {
                    result = '-';
                }
            }
        }

        Console.WriteLine("result: {0}", result);
    }
}