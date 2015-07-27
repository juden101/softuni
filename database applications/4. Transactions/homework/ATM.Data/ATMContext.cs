namespace ATM.Data
{
    using ATM.Data.Migrations;
    using ATM.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ATMContext : DbContext
    {
        public ATMContext()
            : base("name=ATMContext")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<ATMContext, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public IDbSet<CardAccount> CardAccount { get; set; }
        public IDbSet<TransactionHistory> TransactionHistory { get; set; }
    }
}