namespace football
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PhonebookConsoleClient
    {
        public static void Main()
        {
            var context = new PhonebookContext();

            var contacts = context.Contacts
                .Select(c => new
                {
                    name = c.Name,
                    position = c.Position,
                    company = c.Company,
                    site = c.Site,
                    notes = c.Notes,
                    phones = c.Phones.Select(p => p.PhoneNumber),
                    emails = c.Emails.Select(e => e.EmailAddress)
                });

            foreach (var contact in contacts)
            {
                string phones = null;
                if (contact.phones.Count() > 0)
                {
                    phones = string.Join("; ", contact.phones);
                }

                string emails = null;
                if (contact.emails.Count() > 0)
                {
                    emails = string.Join("; ", contact.emails);
                }

                Console.WriteLine("Name: {0}\r\nPosition: {1}\r\nCompany: {2}\r\nSite: {3}\r\nNotes: {4}\r\nPhones: {5}\r\nEmails: {6}\r\n",
                    contact.name ?? "(no)",
                    contact.position ?? "(no)",
                    contact.company ?? "(no)",
                    contact.site ?? "(no)",
                    contact.notes ?? "(no)",
                    phones ?? "(no)",
                    emails ?? "(no)");
            }
        }
    }
}