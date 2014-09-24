using System;

class Program
{
    static void Main()
    {
        DateTime startDate, endDate;

        startDate = DateTime.Parse(Console.ReadLine());
        endDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine((startDate - endDate).TotalDays * -1);
    }
}