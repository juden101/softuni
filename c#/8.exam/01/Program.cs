using System;

class Program
{
    static void Main()
    {
        int s = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int waterMelons = 0, melons = 0, currentWatermelons, currentMelons;

        int currentDay = s;
        for (int i = 0; i < d; i++)
        {
            currentWatermelons = 0;
            currentMelons = 0;

            if (currentDay == 1)
            {
                currentWatermelons = 1;
                currentMelons = 0;
            }
            else if (currentDay == 2)
            {
                currentWatermelons = 0;
                currentMelons = 2;
            }
            else if (currentDay == 3)
            {
                currentWatermelons = 1;
                currentMelons = 1;
            }
            else if (currentDay == 4)
            {
                currentWatermelons = 2;
                currentMelons = 0;
            }
            else if (currentDay == 5)
            {
                currentWatermelons = 2;
                currentMelons = 2;
            }
            else if (currentDay == 6)
            {
                currentWatermelons = 1;
                currentMelons = 2;
            }
            else if (currentDay == 7)
            {
                currentWatermelons = 0;
                currentMelons = 0;
            }

            waterMelons += currentWatermelons;
            melons += currentMelons;

            currentDay++;

            if (currentDay == 8)
            {
                currentDay = 1;
            }
        }
    
        if(waterMelons > melons)
        {
            Console.WriteLine("{0} more watermelons", waterMelons - melons);
        }
        else if(melons > waterMelons)
        {
            Console.WriteLine("{0} more melons", melons - waterMelons);
        }
        else
        {
            Console.WriteLine("Equal amount: {0}", waterMelons);
        }
    }
}