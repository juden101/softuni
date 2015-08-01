namespace football.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhonebookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "football.PhonebookContext";
        }

        protected override void Seed(PhonebookContext context)
        {
            var firstContact = new Contact()
            {
                Name = "Peter Ivanov",
                Position = "CTO",
                Company = "Smart Ideas",
                Emails = new List<Email>()
                {
                    new Email() { EmailAddress = "peter@gmail.com" },
                    new Email { EmailAddress = "peter_ivanov@yahoo.com" }
                },
                Phones = new List<Phone>()
                {
                    new Phone() { PhoneNumber = "+359 2 22 22 22" },
                    new Phone() { PhoneNumber = "+359 88 77 88 99" }
                },
                Site = "http://blog.peter.com",
                Notes = "Friend from school"
            };

            var secondContact = new Contact()
            {
                Name = "Maria",
                Phones = new List<Phone>()
                {
                    new Phone() { PhoneNumber = "+359 22 33 44 55" }
                }
            };

            var thirdContact = new Contact()
            {
                Name = "Angie Stanton",
                Emails = new List<Email>()
                {
                    new Email() { EmailAddress = "info@angiestanton.com" }
                },
                Site = "http://angiestanton.com"
            };

            context.Contacts.AddOrUpdate(
                c => c.Name,
                firstContact,
                secondContact,
                thirdContact
            );

            context.SaveChanges();
        }
    }
}
