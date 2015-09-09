using System;
using System.Collections.Generic;
using System.Linq;

public class PersonCollectionSlow : IPersonCollection
{
    List<Person> persons = new List<Person>();

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.persons.Where(p => p.Email == email).Any())
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

        this.persons.Add(person);
        return true;
    }

    public int Count
    {
        get
        {
            return this.persons.Count;
        }
    }

    public Person FindPerson(string email)
    {
        Person person = this.persons.FirstOrDefault(p => p.Email == email);

        return person;
    }

    public bool DeletePerson(string email)
    {
        Person person = this.persons.FirstOrDefault(p => p.Email == email);

        if (person == null)
        {
            return false;
        }

        this.persons.Remove(person);
        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        var persons = this.persons
            .Where(p => p.Email.EndsWith("@" + emailDomain))
            .OrderBy(p => p.Email);

        return persons;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var persons = this.persons
            .Where(p => p.Name == name && p.Town == town)
            .OrderBy(p => p.Email);

        return persons;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var persons = this.persons
            .Where(p => p.Age >= startAge && p.Age <= endAge)
            .OrderBy(p => p.Age)
            .ThenBy(p => p.Email);

        return persons;
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        var persons = this.persons
            .Where(p => p.Age >= startAge && p.Age <= endAge && p.Town == town)
            .OrderBy(p => p.Age)
            .ThenBy(p => p.Email);

        return persons;
    }
}
