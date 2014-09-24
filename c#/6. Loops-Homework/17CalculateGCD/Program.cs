using System;

class Program
{
    static void Main()
    {
        int a, b, c, r, gcd;

        Console.Write("a = ");
        a = int.Parse(Console.ReadLine());

        Console.Write("b = ");
        b = int.Parse(Console.ReadLine());

        if(a < b)
        {
            c = a;
            a = b;
            b = c;
        }

        while(true)
        {
            r = a % b;

            if (r == 0)
            {
                gcd = b;
                break;
            }

            a = b;
            b = r;
        }

        Console.WriteLine("GCD = {2}", gcd);
    }
}