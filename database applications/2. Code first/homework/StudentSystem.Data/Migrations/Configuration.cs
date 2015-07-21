namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using System.IO;
    using System.Globalization;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "StudentSystem";
        }

        protected override void Seed(StudentSystemContext context)
        {
            Random random = new Random();
            List<Course> courses = this.LoadCourses("../../../Data/courses.txt");
            List<Student> students = this.LoadStudents("../../../Data/students.txt");
            List<Homework> homeworks = this.LoadHomeworks("../../../Data/homeworks.txt");
            List<Resource> resources = this.LoadResources("../../../Data/resources.txt");

            int courseCounter = 0;
            foreach (Course course in courses)
            {
                for (int i = courseCounter; i < courseCounter + 10; i++)
                {
                    course.Resources.Add(resources[i]);
                }

                courseCounter += 10;
            }

            foreach (Student student in students)
            {
                int courseIterations = random.Next(0, courses.Count + 1);
                int homeworksIterations = random.Next(0, 5);

                for (int i = 0; i < courseIterations; i++)
                {
                    Course course = courses[random.Next(courses.Count)];

                    if (!student.Courses.Contains(course))
                    {
                        student.Courses.Add(course);
                    }
                }

                for (int i = 0; i < homeworksIterations; i++)
                {
                    if (student.Courses.Any())
                    {
                        Homework studentHomework = homeworks[random.Next(homeworks.Count)];
                        studentHomework.Course = student.Courses.ElementAt(random.Next(student.Courses.Count));

                        student.Homeworks.Add(studentHomework);
                    }
                }

                context.Students.AddOrUpdate(student);
            }
        }

        private List<Course> LoadCourses(string filePath)
        {
            List<Course> courses = new List<Course>();

            using (var reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                line = reader.ReadLine();

                while (line != null)
                {
                    string[] data = line.Split(new[] { ' ' });

                    string name = data[0];
                    string description = data[1];
                    DateTime startDate = DateTime.ParseExact(data[2], "d/M/yyyy", CultureInfo.InvariantCulture);
                    DateTime endDate = DateTime.ParseExact(data[3], "d/M/yyyy", CultureInfo.InvariantCulture);
                    decimal price = Decimal.Parse(data[4]);

                    Course course = new Course()
                    {
                        Name = name,
                        Description = description,
                        StartDate = startDate,
                        EndDate = endDate,
                        Price = price
                    };

                    courses.Add(course);
                    line = reader.ReadLine();
                }
            }

            return courses;
        }

        private List<Student> LoadStudents(string filePath)
        {
            List<Student> students = new List<Student>();

            using (var reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                line = reader.ReadLine();

                while (line != null)
                {
                    string[] data = line.Split(new[] { ' ' });

                    string name = data[0];
                    string phoneNumber = data[1];
                    DateTime registeredOn = DateTime.ParseExact(data[2], "d/M/yyyy", CultureInfo.InvariantCulture);
                    DateTime birthOn = DateTime.ParseExact(data[3], "d/M/yyyy", CultureInfo.InvariantCulture);

                    Student student = new Student()
                    {
                        Name = name,
                        PhoneNumber = phoneNumber,
                        RegisteredOn = registeredOn,
                        BirthOn = birthOn
                    };

                    students.Add(student);
                    line = reader.ReadLine();
                }
            }

            return students;
        }

        private List<Homework> LoadHomeworks(string filePath)
        {
            List<Homework> homeworks = new List<Homework>();

            using (var reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                line = reader.ReadLine();

                while (line != null)
                {
                    string[] data = line.Split(new[] { ' ' });

                    string content = data[0];
                    ContentType contentType = (ContentType)int.Parse(data[1]);
                    DateTime submittedOn = DateTime.ParseExact(data[2], "d/M/yyyy", CultureInfo.InvariantCulture);

                    Homework homework = new Homework()
                    {
                        Content = content,
                        ContentType = contentType,
                        SubmittedOn = submittedOn
                    };

                    homeworks.Add(homework);
                    line = reader.ReadLine();
                }
            }

            return homeworks;
        }

        private List<Resource> LoadResources(string filePath)
        {
            List<Resource> resources = new List<Resource>();

            using (var reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                line = reader.ReadLine();

                while (line != null)
                {
                    string[] data = line.Split(new[] { ' ' });

                    string name = data[0];
                    ResourceType resourceType = (ResourceType)int.Parse(data[1]);
                    string url = data[2];

                    Resource resource = new Resource()
                    {
                        Name = name,
                        ResourceType = resourceType,
                        URL = url
                    };

                    resources.Add(resource);
                    line = reader.ReadLine();
                }
            }

            return resources;
        }
    }
}