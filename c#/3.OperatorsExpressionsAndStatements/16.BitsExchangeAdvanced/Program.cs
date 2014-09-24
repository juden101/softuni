using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Please enter n: ");
            uint n = uint.Parse(Console.ReadLine());

            Console.Write("Please enter p: ");
            int p = int.Parse(Console.ReadLine());

            Console.Write("Please enter q: ");
            int q = int.Parse(Console.ReadLine());

            Console.Write("Please enter k: ");
            int k = int.Parse(Console.ReadLine());

            if (Math.Max(p, q) + k - 1 > 31)
            {
                Console.WriteLine("out of range");
            }
            else if (Math.Min(p, q) + k - 1 >= Math.Max(p, q))
            {
                Console.WriteLine("overlapping");
            }
            else
            {
                for (int i = p; i <= p + k - 1; i++)
                {
                    uint mask = 1;

                    uint bitQ = (n & (mask << q)) >> q;
                    uint bitP = (n & (mask << i)) >> i;

                    n = n & ~(mask << i);
                    n = n & ~(mask << q);

                    n = n | (bitQ << i);
                    n = n | (bitP << q);

                    q++;
                }

                Console.WriteLine(n);
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("out of range");
        }
    }
}