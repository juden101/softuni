using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        bool isFound = false;
        int dateWeight;
        DateTime startYear, endYear;
        List<string> magicDates = new List<string>();

        startYear = new DateTime(int.Parse(Console.ReadLine()), 1, 1);
        endYear = new DateTime(int.Parse(Console.ReadLine()), 12, 31);
        dateWeight = int.Parse(Console.ReadLine());

        while (endYear >= startYear)
        {
            string currentDate = startYear.Day.ToString("00") + startYear.Month.ToString("00") + startYear.Year;

            int currentDateWeight = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int a = i; a < 7; a++)
                {
                    currentDateWeight += Int32.Parse(currentDate[i].ToString()) * Int32.Parse(currentDate[a + 1].ToString());
                }
            }

            if (currentDateWeight == dateWeight)
            {
                string magicDate = currentDate.Insert(2, "-").Insert(5, "-");
                magicDates.Add(magicDate);

                isFound = true;
            }

            startYear = startYear.AddDays(1);
        }

        if(isFound)
        {
            foreach (string item in magicDates)
            {
                Console.WriteLine(item);
            }
        }
        else 
        {
            Console.WriteLine("No");
        }
    }
}