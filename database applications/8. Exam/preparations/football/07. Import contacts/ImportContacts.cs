namespace football
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    class ImportContacts
    {
        static void Main()
        {
            var phonebookContext = new PhonebookContext();

            string jsonContacts = File.ReadAllText("../../contacts.json");
            var contacts = JsonConvert.DeserializeObject<ContactDTO[]>(jsonContacts);

            foreach (var contactDTO in contacts)
            {
                try
                {
                    if (contactDTO.Name == null)
                    {
                        throw new ArgumentException("Name is requeired.");
                    }

                    var contact = new Contact()
                    {
                        Name = contactDTO.Name,
                        Position = contactDTO.Position,
                        Company = contactDTO.Company,
                        Site = contactDTO.Site,
                        Notes = contactDTO.Notes
                    };

                    if (contactDTO.Emails != null)
                    {
                        contact.Emails = contactDTO.Emails.Select(e => new Email() { EmailAddress = e }).ToList();
                    }

                    if (contactDTO.Phones != null)
                    {
                        contact.Phones = contactDTO.Phones.Select(pn => new Phone() { PhoneNumber = pn }).ToList();
                    }

                    var context = new PhonebookContext();
                    context.Contacts.Add(contact);
                    context.SaveChanges();

                    Console.WriteLine("Contact {0} imported", contactDTO.Name);
                }
                catch (ArgumentException exc)
                {
                    Console.WriteLine("Error: {0}", exc.Message);
                }
            }
        }
    }
}