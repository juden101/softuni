using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public abstract class CourseBase
    {
        private const int MinLengthForStrings = 2;

        private string courseName;
        private string teacherName;
        protected IList<string> students;

        protected CourseBase(string courseName)
        {
            this.CourseName = courseName;
        }

        protected CourseBase(string courseName, string teacherName)
            : this(courseName)
        {
            this.TeacherName = teacherName;
        }

        protected CourseBase(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName)
        {
            this.Students = students;
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("courseName", "Course name cannot be null.");
                }
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinLengthForStrings)
                {
                    throw new ArgumentException("Course name must be at least 2 chars.", "courseName");
                }

                this.courseName = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("teacherName", "Teacher's name cannot be null.");
                }
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinLengthForStrings)
                {
                    throw new ArgumentException("teacher's name must be at least 2 chars.", "TeacherName");
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                if (value == null)
                {
                    this.students = new List<string>();
                }

                this.students = value;
            }
        }

        protected string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("{ Name = ");
            result.Append(this.CourseName);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }
            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }
    }
}
