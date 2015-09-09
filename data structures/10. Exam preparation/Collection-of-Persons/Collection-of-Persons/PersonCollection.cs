using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    Dictionary<string, Person> peopleByEmail = new Dictionary<string, Person>();
    Dictionary<string, SortedSet<Person>> peopleByEmailDomain = new Dictionary<string, SortedSet<Person>>();
    Dictionary<string, SortedSet<Person>> peopleByNameAndTown = new Dictionary<string, SortedSet<Person>>();
    OrderedDictionary<int, SortedSet<Person>> peopleByAge = new OrderedDictionary<int, SortedSet<Person>>();
    Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> peopleByAgeAndTown = new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        Person person = new Person()
        {
            Email = email,
            Name = name,
            Age = age,
            Town = town
        };

        if (this.peopleByEmail.ContainsKey(email))
        {
            return false;
        }

        // add by email
        this.peopleByEmail.Add(email, person);

        // add by email domain
        string emailDomain = this.ExtractEmailDomain(email);

        if (!peopleByEmailDomain.ContainsKey(emailDomain))
        {
            this.peopleByEmailDomain.Add(emailDomain, new SortedSet<Person>());
        }

        this.peopleByEmailDomain[emailDomain].Add(person);

        // add by name and town
        string nameAndTownKey = this.CombineNameAndTown(name, town);

        if (!this.peopleByNameAndTown.ContainsKey(nameAndTownKey))
        {
            this.peopleByNameAndTown.Add(nameAndTownKey, new SortedSet<Person>());
        }

        peopleByNameAndTown[nameAndTownKey].Add(person);

        // add by age
        if (!this.peopleByAge.ContainsKey(person.Age))
        {
            this.peopleByAge.Add(person.Age, new SortedSet<Person>());
        }

        peopleByAge[person.Age].Add(person);

        // add by age and town
        if (!this.peopleByAgeAndTown.ContainsKey(person.Town))
        {
            this.peopleByAgeAndTown.Add(person.Town, new OrderedDictionary<int, SortedSet<Person>>());
        }

        if (!this.peopleByAgeAndTown[person.Town].ContainsKey(person.Age))
        {
            this.peopleByAgeAndTown[person.Town].Add(person.Age, new SortedSet<Person>());
        }

        this.peopleByAgeAndTown[person.Town][person.Age].Add(person);

        return true;
    }

    public int Count
    {
        get
        {
            return peopleByEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        Person person;
        this.peopleByEmail.TryGetValue(email, out person);

        return person;
    }

    public bool DeletePerson(string email)
    {
        var person = this.FindPerson(email);

        if (person == null)
        {
            return false;
        }

        // remove by email
        this.peopleByEmail.Remove(email);

        // remove by email domain
        string emailDomain = this.ExtractEmailDomain(person.Email);
        this.peopleByEmailDomain[emailDomain].Remove(person);

        // add by name and town
        string nameAndTownKey = this.CombineNameAndTown(person.Name, person.Town);
        this.peopleByNameAndTown[nameAndTownKey].Remove(person);

        // remove by age
        this.peopleByAge[person.Age].Remove(person);

        // remove by age and town
        this.peopleByAgeAndTown[person.Town][person.Age].Remove(person);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        if (this.peopleByEmailDomain.ContainsKey(emailDomain))
        {
            foreach (var person in this.peopleByEmailDomain[emailDomain])
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        string nameAndTownKey = this.CombineNameAndTown(name, town);

        if (this.peopleByNameAndTown.ContainsKey(nameAndTownKey))
        {
            foreach (var person in this.peopleByNameAndTown[nameAndTownKey])
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var peopleInRange = this.peopleByAge.Range(startAge, true, endAge, true);

        foreach (var people in peopleInRange)
        {
            foreach (var person in people.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        if (!this.peopleByAgeAndTown.ContainsKey(town))
        {
            yield break;
        }

        var peopleInRange = this.peopleByAgeAndTown[town].Range(startAge, true, endAge, true);

        foreach (var people in peopleInRange)
        {
            foreach (var person in people.Value)
            {
                yield return person;
            }
        }
    }

    private string ExtractEmailDomain(string email)
    {
        return email.Split('@')[1];
    }

    private string CombineNameAndTown(string name, string town)
    {
        return string.Format("{0}-{1}", name, town);
    }
}