namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;

    using StudentSystem.Data;
    using System.Data.Entity.Core.Objects;

    class StudentSystemConsoleClient
    {
        static void Main()
        {
            var context = new StudentSystemContext();
            
            // 1. Lists all students and their homework submissions.
            // Select only their names and for each homework - content and content-type.

            var studentsWithHomeworks = context.Students
                .Select(s => new
                {
                    s.Name,
                    Homeworks = s.Homeworks
                        .Select(h => new
                        {
                            h.Content,
                            h.ContentType
                        })
                        .ToList()
                })
                .ToList();
            
            foreach (var student in studentsWithHomeworks)
            {
                Console.WriteLine("-- {0}", student.Name);

                if (student.Homeworks.Any())
                {
                    foreach (var homework in student.Homeworks)
                    {
                        Console.WriteLine("[{0}] - {1}", homework.Content, homework.ContentType);
                    }
                }
                else
                {
                    Console.WriteLine("(No homeworks)");
                }
            }

            // 2. List all courses with their corresponding resources.
            // Select the course name and description and everything for each resource.
            // Order the courses by start date (ascending), then by end date (descending).

            var coursesWithResources = context.Courses
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    Resources = c.Resources.ToList()
                })
                .ToList();

            foreach (var course in coursesWithResources)
            {
                Console.WriteLine("-- {0} - {1}", course.Name, course.Description);

                foreach (var resource in course.Resources)
                {
                    Console.WriteLine("{0} - {1} - {2}", resource.Name, resource.ResourceType, resource.URL);
                }
            }

            // 3. List all courses with more than 5 resources.
            // Order them by resources count (descending), then by start date (descending).
            // Select only the course name and the resource count.

            var coursesWithMoreThan5Resources = context.Courses
                .OrderByDescending(c => c.Resources.Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                {
                    c.Name,
                    c.Resources.Count
                })
                .ToList();

            foreach (var course in coursesWithMoreThan5Resources)
            {
                Console.WriteLine("-- {0} - {1}", course.Name, course.Count);
            }

            // 4. List all courses which were active on a given date (choose the date depending
            // on the data seeded to ensure there are results), and for each course count the number of students enrolled. 
            // Select the course name, start and end date, course duration (difference between end and start date)
            // and number of students enrolled. Order the results by the number of students
            // enrolled (in descending order), then by duration (descending).

            DateTime specificDate = new DateTime(2014, 7, 5);
            var activeCoursesOnGivenDate = context.Courses
                .Where(c => c.StartDate <= specificDate && specificDate <= c.EndDate)
                .OrderByDescending(c => c.Students.Count())
                .ThenByDescending(c => EntityFunctions.DiffDays(c.StartDate, c.EndDate))
                .Select(c => new
                {
                    c.Name,
                    c.StartDate,
                    c.EndDate,
                    Duration = EntityFunctions.DiffDays(c.StartDate, c.EndDate),
                    StudentsCount = c.Students.Count
                })
                .ToList();

            foreach (var course in activeCoursesOnGivenDate)
            {
                Console.WriteLine("-- {0}, start: {1}, end: {2}, duration: {3} days, students: {4}",
                    course.Name,
                    course.StartDate,
                    course.EndDate,
                    course.Duration,
                    course.StudentsCount);
            }

            // 5. For each student, calculate the number of courses he/she has enrolled in,
            // the total price of these courses and the average price per course for the student.
            // Select the student name, number of courses, total price and average price.
            // Order the results by total price (descending), then by number of courses (descending)
            // and then by the student's name (ascending).

            var studentsWithCourses = context.Students
                .Where(s => s.Courses.Any())
                .OrderByDescending(s => s.Courses.Sum(c => c.Price))
                .ThenByDescending(s => s.Courses.Count)
                .ThenBy(s => s.Name)
                .Select(s => new
                {
                    s.Name,
                    EnrolledCourses = s.Courses.Count,
                    TotalPrice = s.Courses.Sum(c => c.Price),
                    AveragePrice = s.Courses.Average(c => (int)c.Price)
                })
                .ToList();

            foreach (var student in studentsWithCourses)
            {
                Console.WriteLine("-- {0}, courses: {1}, total price: {2}, average price: {3:f2}",
                    student.Name,
                    student.EnrolledCourses,
                    student.TotalPrice,
                    student.AveragePrice);
            }
        }
    }
}