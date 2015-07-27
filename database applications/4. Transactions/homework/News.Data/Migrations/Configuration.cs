namespace News.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<NewsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NewsContext context)
        {
            context.News.AddOrUpdate(
                n => n.Content,
                new News("Shanghai stocks sink 8.5%"),
                new News("Merlin shares tumble on profit warning"),
                new News("Upbeat Reckitt raises growth forecasts"),
                new News("UBS second-quarter profits beat forecasts"),
                new News("Economist sale offers cachet not control"),
                new News("Osborne faces diplomatic test in Paris"),
                new News("Bailout monitors raise doubts over Greece")
            );
        }
    }
}
