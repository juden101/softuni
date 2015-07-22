namespace PerformanceHomework
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var context = new AdsEntities();
            Stopwatch stopwatch = new Stopwatch();

            context.Database.SqlQuery<string>("CHECKPOINT; DBCC DROPCLEANBUFFERS;");

            stopwatch.Start();

            var selectAllCoulmns = context.Ads.ToList();

            foreach (var ad in selectAllCoulmns)
            {
                Console.WriteLine(ad.Title);
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();

            var selectOnlyTitle = context.Ads.Select(a => a.Title).ToList();

            foreach (var ad in selectOnlyTitle)
            {
                Console.WriteLine(ad);
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}