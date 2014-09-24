using System;

class Program
{
    static void Main()
    {
        string yearType = Console.ReadLine();
        int p = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());

        int yearWeekends = 48;
        double playing = 0;

        playing += h;
        playing += (yearWeekends - h) * 3 / 4d;
        playing += p * 2 / 3d;

        if(yearType == "leap")
        {
            playing += playing * 15 / 100d;
        }

        Console.WriteLine(Math.Floor(playing));
    }
}