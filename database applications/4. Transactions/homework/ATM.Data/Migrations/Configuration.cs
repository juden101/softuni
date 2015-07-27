namespace ATM.Data.Migrations
{
    using ATM.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ATM.Data.ATMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ATM.Data.ATMContext context)
        {
            var db = new ATMContext();

            var cardAccounts = new List<CardAccount>
            {
                new CardAccount("1234567890", "1234", 999.9m),
                new CardAccount("9876543210", "9874", 15000.3m),
                new CardAccount("8949848946", "4892", 66.6m),
                new CardAccount("6489123898", "4945", 0.0m),
                new CardAccount("4984548887", "8135", 99m),
                new CardAccount("7981528365", "7753", 617.21m)
            };

            cardAccounts.ForEach(delegate(CardAccount c)
            {
                if (!db.CardAccount.Any(x => c.CardNumber == x.CardNumber))
                {
                    db.CardAccount.AddOrUpdate(c);
                }
            });

            db.SaveChanges();
        }
    }
}