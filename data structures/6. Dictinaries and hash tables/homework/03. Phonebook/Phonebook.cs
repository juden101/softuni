using System;
using System.Collections.Generic;

public class Phonebook
{
    public static void Main()
    {
        HashTable<string, string> phonebook = new HashTable<string, string>();
        Queue<string> output = new Queue<string>();

        string input = Console.ReadLine();
        while(input != "search")
        {
            string name = input.Split('-')[0];
            string phoneNumber = input.Split('-')[1];

            phonebook.AddOrReplace(name, phoneNumber);
            input = Console.ReadLine();
        }

        input = Console.ReadLine();

        while (input != string.Empty)
        {
            KeyValue<string, string> contact = phonebook.Find(input);

            if (contact == null)
            {
                output.Enqueue(string.Format("Contact {0} does not exist.", input));
            }
            else
            {
                output.Enqueue(string.Format("{0} -> {1}", contact.Key, contact.Value));
            }

            input = Console.ReadLine();
        }
        
        foreach (string result in output)
        {
            Console.WriteLine(result);
        }
    }
}