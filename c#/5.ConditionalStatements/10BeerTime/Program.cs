using System;

class Program
{
    static void Main()
    {
        string date = Console.ReadLine();
        DateTime dateTime;

        if (DateTime.TryParse(date, out dateTime))
        {
            if (dateTime.Hour > 12 || dateTime.Hour < 3)
            {
                Console.WriteLine("beer time");
            }
            else
            {
                Console.WriteLine("non-beer time");
            }
        }
        else
        {
            Console.WriteLine("invalid time");
        }
    }
}