using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> personsByEmail;
    private Dictionary<string, SortedSet<Person>> personsByEmailDomain;
    private Dictionary<string, SortedSet<Person>> personsByNameAndTown;
    private OrderedDictionary<int, SortedSet<Person>> personsByAge;
    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTownAndAge;

    public PersonCollection()
    {
        this.personsByEmail = new Dictionary<string, Person>();
        this.personsByEmailDomain = new Dictionary<string, SortedSet<Person>>();
        this.personsByNameAndTown = new Dictionary<string, SortedSet<Person>>();
        this.personsByAge = new OrderedDictionary<int, SortedSet<Person>>();
        this.personsByTownAndAge = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.FindPerson(email) != null)
        {
            return false;
        }

        Person person = new Person()
        {
            Email = email,
            Name = name,
            Age = age,
            Town = town
        };

        // Add by email
        this.personsByEmail.Add(email, person);

        // Add by email domain
        var emailDomain = this.ExtractEmailDomain(email);
        this.personsByEmailDomain.AppendValueToKey(emailDomain, person);

        // Add by name and town
        var nameAndTown = this.CombineNameAndTown(name, town);
        this.personsByNameAndTown.AppendValueToKey(nameAndTown, person);

        // Add by age
        this.personsByAge.AppendValueToKey(age, person);

        // Add by town and age
        this.personsByTownAndAge.EnsureKeyExists(town);
        this.personsByTownAndAge[town].AppendValueToKey(age, person);

        return true;
    }

    public int Count
    {
        get
        {
            return this.personsByEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        Person person;

        this.personsByEmail.TryGetValue(email, out person);

        return person;
    }

    public bool DeletePerson(string email)
    {
        var person = this.FindPerson(email);

        if (person == null)
        {
            return false;
        }

        // Delete from personsByEmail
        this.personsByEmail.Remove(email);

        // Delete from personsByEmailDomain
        var emailDomain = this.ExtractEmailDomain(email);
        this.personsByEmailDomain[emailDomain].Remove(person);

        // Delete from personsByNameAndTown
        var nameAndTown = this.CombineNameAndTown(person.Name, person.Town);
        this.personsByNameAndTown[nameAndTown].Remove(person);

        // Delete from personsByAge
        this.personsByAge[person.Age].Remove(person);

        // Delete from personsByTownAndAge
        this.personsByTownAndAge[person.Town][person.Age].Remove(person);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        return this.personsByEmailDomain.GetValuesForKey(emailDomain);
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var nameAndTown = this.CombineNameAndTown(name, town);

        return this.personsByNameAndTown.GetValuesForKey(nameAndTown);
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var personsInRange = this.personsByAge.Range(startAge, true, endAge, true);

        foreach (var personsByAge in personsInRange)
        {
            foreach (var person in personsByAge.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.personsByTownAndAge.ContainsKey(town))
        {
            yield break;
        }

        var personsInRange = personsByTownAndAge[town].Range(startAge, true, endAge, true);

        foreach (var personsByAge in personsInRange)
        {
            foreach (var person in personsByAge.Value)
            {
                yield return person;
            }
        }
    }

    private string ExtractEmailDomain(string email)
    {
        var domain = email.Split('@')[1];

        return domain;
    }

    private string CombineNameAndTown(string name, string town)
    {
        const string separator = "|!|";

        return string.Format("{0}{1}{2}", name, separator, town);
    }
}
