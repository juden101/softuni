using System;
using System.Collections.Generic;
using System.Linq;

class Test
{
    static void Main()
    {
        List<Student> students = new List<Student>()
        {
            new Student("Mihail", "Nikolov", 19, "245121493", "+359-978-6458", new List<int>() { 6, 6, 6, 6 }, 4, "mishoka@abv.bg", "Beginner"),
            new Student("Ivan", "Petrov", 23, "245121457", "+359-878-7965", new List<int>() { 3, 5, 4, 5 }, 3, "bat_ivan@gmail.com", "Senior"),
            new Student("Ivan", "Ivanov", 23, "245121572", "+359-878-7965", new List<int>() { 3, 5, 4, 5 }, 3, "van4eto@abv.bg", "Ninja"),
            new Student("Radoslav", "Hokov", 25, "245121523", "02-897-7895", new List<int>() { 4, 3, 5, 6 }, 2, "radi@abv.bg", "Ninja"),
            new Student("Petar", "Ivanov", 32, "245121585", "+359-787-9756", new List<int>() { 6, 3, 5, 6 }, 1, "pe6o@hotmail.com", "Beginner"),
            new Student("Nikola", "Benkov", 27, "245121405", "+3592-888-7389", new List<int>() { 5, 5, 4, 5 }, 3, "nikito@gmail.com", "Ninja"),
            new Student("Svetoslav", "Gavadinov", 20, "245121511", "+359-875-5468", new List<int>() { 2, 3, 2, 4 }, 4, "svetlio@abv.bg", "Senior")
        };

        // Problem 4. Students by Group
        var orderedStudentsByFirstName =
            from student in students
            orderby student.FirstName
            select student;
        PrintStudents(orderedStudentsByFirstName);

        Console.WriteLine("\n\n");

        // Problem 5. Students by First and Last Name
        var orderedStudentsByFirstAndLastName =
            from student in students
            orderby student.FirstName, student.LastName
            select student;
        PrintStudents(orderedStudentsByFirstAndLastName);

        Console.WriteLine("\n\n");

        // Problem 6. Students by Age
        var orderedStudentsByAge =
            from student in students
            orderby student.Age
            select student;
        PrintStudents(orderedStudentsByAge);

        Console.WriteLine("\n\n");

        // Problem 7. Sort Students
        var orderedStudentsLambdaFirstAndLastName = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);
        PrintStudents(orderedStudentsLambdaFirstAndLastName);

        Console.WriteLine("\n\n");

        // Problem 8. Filter Students by Email Domain
        var orderedStudentsByEmail =
            from student in students
            where student.Email.Contains("@abv.bg")
            select student;
        PrintStudents(orderedStudentsByEmail);

        Console.WriteLine("\n\n");

        // Problem 9. Filter Students by Phone
        var orderedStudentsByPhone =
            from student in students
            where student.Phone.StartsWith("02") || student.Phone.StartsWith("+3592") || student.Phone.StartsWith("+359 2")
            select student;
        PrintStudents(orderedStudentsByPhone);

        Console.WriteLine("\n\n");

        // Problem 10. Excellent Students
        var orderedStudentsByExcellentMark =
            from student in students
            where student.Marks.Contains(6)
            select new { FirstName = student.FirstName, Marks = student.Marks };

        foreach (var student in orderedStudentsByExcellentMark)
        {
            string marks = string.Join(", ", student.Marks);
            Console.WriteLine("{0}: ({1})", student.FirstName, marks);
        }

        Console.WriteLine("\n\n");

        // Problem 11. Weak Students
        var orderedStudentsByWeakMark =
            from student in students
            where student.Marks.Where(mark => mark == 2).Count() == 2
            select student;
        PrintStudents(orderedStudentsByWeakMark);

        Console.WriteLine("\n\n");

        // Problem 12. Students Enrolled in 2014
        var orderedStudentsEnrolledIn2014 = students.Where(student => student.FacultyNumber.ToString().Substring(5, 2) == "14");
        PrintStudents(orderedStudentsEnrolledIn2014);

        Console.WriteLine("\n\n");

        // Problem 12.* Students by Group

        var groups =
            from student in students
            group student by student.GroupName into g
            orderby g.Key
            select g;

        foreach (var item in groups)
        {
            Console.WriteLine("\n{0}:", item.Key);
            var tempStudents = students.Where(s => s.GroupName == item.Key);

            foreach (var student in tempStudents)
            {
                Console.WriteLine(student);
            }
        }

        Console.WriteLine("\n\n");

        // Problem 13.* Students Joined to Specialties
        StudentSpecialty Mihail = new StudentSpecialty("Software Enginering", "245121493");
        StudentSpecialty Ivan = new StudentSpecialty("QA", "245121457");

        List<StudentSpecialty> specialties = new List<StudentSpecialty>();
        specialties.Add(Mihail);
        specialties.Add(Ivan);

        var studentsWithSpecialties =
            from speciality in specialties
            join student in students on speciality.FacultyNumber equals student.FacultyNumber
            select new { student, FacultyName = speciality.SpecialityName };

        foreach (var item in studentsWithSpecialties)
        {
            Console.WriteLine(item);
        }
    }

    public static void PrintStudents(IEnumerable<Student> students)
    {
        foreach (Student student in students)
        {
            Console.WriteLine(student);
        }
    }

}