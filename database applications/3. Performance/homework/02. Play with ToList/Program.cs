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

            var allAds = context.Ads
                .ToList()
                .Where(a => a.AdStatus.Status == "Published")
                .Select(a => new
                {
                    a.Title,
                    Category = a.Category.Name,
                    Town = a.Town.Name,
                    a.Date
                })
                .OrderBy(a => a.Date);

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();

            var improvedAllAds = context.Ads
                .Where(a => a.AdStatus.Status == "Published")
                .OrderBy(a => a.Date)
                .Select(a => new
                {
                    a.Title,
                    Category = a.Category.Name,
                    Town = a.Town.Name
                })
                .ToList();

            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }
}