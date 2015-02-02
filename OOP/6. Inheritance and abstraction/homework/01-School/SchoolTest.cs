namespace School
{
    using System;
    using System.Collections.Generic;

    public class SchoolTest
    {
        static void Main()
        {
            List<Student> studentsList = new List<Student>
            {
                new Student("Pesho", 204014, "very good student"),
                new Student("Gosho", 234314),
                new Student("Maria", 152314),
            };

            var disciplinesList = new List<Disciplines>
            {
                new Disciplines("OOP", 140, studentsList, "the best course"),
                new Disciplines("JavaScript", 100, studentsList),
                new Disciplines("Structures and Algorithms", 120, studentsList),
            };

            List<Teacher> teachersList = new List<Teacher>
            {
                new Teacher("Gosho", disciplinesList, "the best teacher"),
                new Teacher("Ivan", disciplinesList),
                new Teacher("Stoyan", disciplinesList),
            };

            Classes firstClass = new Classes("OOP", teachersList, "some details");
        }
    }
}