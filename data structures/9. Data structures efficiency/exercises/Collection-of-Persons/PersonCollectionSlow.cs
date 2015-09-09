﻿using System;
using System.Collections.Generic;
using System.Linq;

public class PersonCollectionSlow : IPersonCollection
{
    private List<Person> persons;

    public PersonCollectionSlow()
    {
        this.persons = new List<Person>();
    }

    public bool AddPerson(string email, string name, int age, string town)
    {
        if (this.FindPerson(email) != null)
        {
            return false;
        }

        Person newPerson = new Person()
        {
            Email = email,
            Name = name,
            Age = age,
            Town = town
        };

        this.persons.Add(newPerson);
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
        return this.persons.FirstOrDefault(p => p.Email == email);
    }

    public bool DeletePerson(string email)
    {
        var person = this.FindPerson(email);

        return this.persons.Remove(person);
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        var personMatches = this.persons
            .Where(p => p.Email.EndsWith("@" + emailDomain))
            .OrderBy(p => p.Email);

        return personMatches;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var personMatches = this.persons
            .Where(p => p.Name == name && p.Town == town)
            .OrderBy(p => p.Email);

        return personMatches;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var personMatches = this.persons
            .Where(p => p.Age >= startAge && p.Age <= endAge)
            .OrderBy(p => p.Age)
            .ThenBy(p => p.Email);

        return personMatches;
    }

    public IEnumerable<Person> FindPersons(
        int startAge, int endAge, string town)
    {
        var personMatches = this.persons
            .Where(p => p.Town == town)
            .Where(p => p.Age >= startAge && p.Age <= endAge)
            .OrderBy(p => p.Age)
            .ThenBy(p => p.Email);

        return personMatches;
    }
}
