namespace PerformanceHomework
{
    using System;
    using System.Linq;
    using System.Data.Entity;

    class Program
    {
        static void Main()
        {
            var context = new AdsEntities();

            // 25 requests without Include(...)
            var allAds = context.Ads.ToList();

            foreach (var ad in allAds)
            {
                Console.WriteLine("+-----------{0}Title: {1}{0}Status: {2}{0}Category: {3}{0}Town: {4}{0}User: {5}",
                    "\r\n",
                    ad.Title,
                    ad.AdStatus.Status,
                    (ad.CategoryId == null ? "(no category)" : ad.Category.Name),
                    (ad.TownId == null ? "(no town)" : ad.Town.Name),
                    (ad.AspNetUser.Id == null ? "(no owner)" : ad.AspNetUser.UserName));
            }

            // 1 request without Include(...)
            var selectedAds = context.Ads
                .Include(a => a.AdStatus)
                .Include(a => a.Category)
                .Include(a => a.Town)
                .Include(a => a.AspNetUser);

            foreach (var ad in selectedAds)
            {
                Console.WriteLine("+-----------{0}Title: {1}{0}Status: {2}{0}Category: {3}{0}Town: {4}{0}User: {5}",
                    "\r\n",
                    ad.Title,
                    ad.AdStatus.Status,
                    (ad.CategoryId == null ? "(no category)" : ad.Category.Name),
                    (ad.TownId == null ? "(no town)" : ad.Town.Name),
                    (ad.AspNetUser.Id == null ? "(no owner)" : ad.AspNetUser.UserName));
            }
        }
    }
}