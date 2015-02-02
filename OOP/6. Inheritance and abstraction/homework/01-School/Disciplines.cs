namespace School
{
    using System;
    using System.Collections.Generic;

    public class Disciplines
    {
        private string name;
        private int numOfLectures;
        private List<Student> students;
        private string details;

        public Disciplines(string name, int numOfLecturs, List<Student> students, string details = null)
        {
            this.Name = name;
            this.NumOfLectuers = numOfLectures;
            this.Students = students;
            this.Details = details;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can not be an empty string");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Name can not be less than 3 charachters");
                }

                this.name = value;
            }
        }

        public int NumOfLectuers
        {
            get { return this.numOfLectures; }
            private set
            {
                this.numOfLectures = value;
            }
        }

        public List<Student> Students
        {
            get { return new List<Student>(this.students); }
            private set { this.students = value; }
        }

        public string Details
        {
            get { return this.details; }
            private set
            {
                if (String.Empty == value)
                {
                    throw new ArgumentNullException("Details can not be an empty string");
                }

                this.details = value;
            }
        }
    }
}