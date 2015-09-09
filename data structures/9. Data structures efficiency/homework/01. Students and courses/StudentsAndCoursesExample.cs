using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class StudentsAndCoursesExample
{
    static void Main()
    {
        SortedDictionary<string, SortedSet<Person>> personsAndCourses = new SortedDictionary<string, SortedSet<Person>>();

        using (StreamReader reader = new StreamReader("../../students.txt"))
        {
            while (!reader.EndOfStream)
            {
                string currentLine = reader.ReadLine();
                string[] tokens = currentLine.Split('|');

                string firstName = tokens[0].Trim();
                string lastName = tokens[1].Trim();
                string courseName = tokens[2].Trim();

                Person person = new Person()
                {
                    FirstName = firstName,
                    LastName = lastName
                };

                if (!personsAndCourses.ContainsKey(courseName))
                {
                    personsAndCourses.Add(courseName, new SortedSet<Person>());
                }

                personsAndCourses[courseName].Add(person);
            }
        }
        
        foreach (var course in personsAndCourses)
        {
            Console.WriteLine("{0}: {1}", course.Key, string.Join(", ", course.Value));
        }
    }
}