using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoroTheFootballPlayer
{
    class Program
    {
        static void Main()
        {
            char yearType = char.Parse(Console.ReadLine());
            int holidays = int.Parse(Console.ReadLine());
            int hometownWeekends = int.Parse(Console.ReadLine());

            int totalPlays = 0;
            int normalWeekends = 52 - hometownWeekends;

            totalPlays += (normalWeekends * 2) / 3;
            totalPlays += holidays / 2;
            totalPlays += hometownWeekends;

            if (yearType == 't')
            {
                totalPlays += 3;
            }

            Console.WriteLine(totalPlays);
        }
    }
}
