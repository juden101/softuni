namespace football
{
    using football.Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhonebookContext : DbContext
    {
        public PhonebookContext()
            : base("name=PhonebookContext")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<PhonebookContext, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Email> Emails { get; set; }

        public virtual DbSet<Phone> Phones { get; set; }
    }
}