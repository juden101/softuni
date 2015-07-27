namespace News.ConsoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Models;
    using Data;
    using System.Data.Entity.Infrastructure;

    class NewsConsoleApplication
    {
        static void Main()
        {
            Console.WriteLine("Application started.");

            MakeUpdate();   
        }

        private static void MakeUpdate()
        {
            var newsContext = new NewsContext();
            var firstNews = newsContext.News.OrderBy(n => n.Id).First();

            Console.WriteLine("Text from DB: {0}", firstNews.Content);
            Console.Write("User input: ");

            using (var dbContextTransaction = newsContext.Database.BeginTransaction())
            {
                try
                {
                    var input = Console.ReadLine();

                    firstNews.Content = input;
                    newsContext.SaveChanges();
                    dbContextTransaction.Commit();

                    Console.WriteLine("Changes successfully saved in the DB.");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    dbContextTransaction.Rollback();
                    Console.WriteLine("Conflict!");

                    MakeUpdate();
                }
            }
        }
    }
}