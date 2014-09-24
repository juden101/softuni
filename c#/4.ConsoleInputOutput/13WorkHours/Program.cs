using System;

    class Program
    {
        static void Main()
        {
            double h, d, p;

            h = double.Parse(Console.ReadLine());
            d = double.Parse(Console.ReadLine());
            p = double.Parse(Console.ReadLine());

            double workHours = Math.Floor(((d - (d * 10 / 100)) * 12) * p / 100);

            if (workHours - h >= 0)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

            Console.WriteLine(workHours - h);
        }
    }