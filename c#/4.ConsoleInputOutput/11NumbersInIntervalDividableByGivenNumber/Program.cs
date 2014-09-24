using System;
class Program
{
    static void Main()
    {
        int start, end, p, concats = 0;
        string dividables = "";

        Console.Write("start: ");
        start = int.Parse(Console.ReadLine());

        Console.Write("end: ");
        end = int.Parse(Console.ReadLine());

        Console.Write("p: ");
        p = int.Parse(Console.ReadLine());

        if(p == 0)
        {
            dividables = "-";
        }
        else
        {
            for (int i = start; i <= end; i++)
            {
                if (i % 5 == 0)
                {
                    if (++concats == p)
                    {
                        dividables += i;
                    }
                    else
                    {
                        dividables += i + ", ";
                    }
                }
            }
        }

        Console.WriteLine(dividables);
    }
}