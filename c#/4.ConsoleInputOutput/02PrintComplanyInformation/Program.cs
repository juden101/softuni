using System;
class Program
{
    static void Main()
    {
        string companyName, companyAddress, phoneNumber, faxNumber, webSite, managerFirstName, managerLastName, managerAge, managerPhone;

        Console.Write("Company name: ");
        companyName = Console.ReadLine();

        Console.Write("Company address: ");
        companyAddress = Console.ReadLine();

        Console.Write("Phone number: ");
        phoneNumber = Console.ReadLine();

        Console.Write("Fax number: ");
        faxNumber = Console.ReadLine();

        Console.Write("Web site: ");
        webSite = Console.ReadLine();

        Console.Write("Manager first name: ");
        managerFirstName = Console.ReadLine();

        Console.Write("Manager last name: ");
        managerLastName = Console.ReadLine();

        Console.Write("Manager age: ");
        managerAge = Console.ReadLine();

        Console.Write("Manager phone: ");
        managerPhone = Console.ReadLine();

        if (companyName != "")
        {
            Console.WriteLine(companyName);
        }

        if (companyAddress != "")
        {
            Console.WriteLine("Address: {0}", companyAddress);
        }
        else
        {
            Console.WriteLine("Address: (unknown)");
        }

        if (phoneNumber != "")
        {
            Console.WriteLine("Tel. {0}", phoneNumber);
        }
        else
        {
            Console.WriteLine("Tel. (no tel.)");
        }

        if (faxNumber != "")
        {
            Console.WriteLine("Fax: {0}", faxNumber);
        }
        else
        {
            Console.WriteLine("Fax: (no fax)");
        }

        if (webSite != "")
        {
            Console.WriteLine("Website: {0}", webSite);
        }
        else
        {
            Console.WriteLine("Website: (unknown)");
        }

        Console.WriteLine("Manager: {0}{1}, {2}, {3}", managerFirstName, managerLastName, managerAge, managerPhone);
    }
}