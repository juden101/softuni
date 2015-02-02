namespace School
{
    using System;
    using System.Collections.Generic;

    public class Classes
    {
        private string textIdentifier;
        private List<Teacher> teachers;
        private string details;

        public Classes(string textIdentifier, List<Teacher> teachers, string details = null)
        {
            this.TextIdentifier = textIdentifier;
            this.Teachers = teachers;
            this.Details = details;
        }

        public string TextIdentifier
        {
            get { return this.textIdentifier; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Classes's text identifier can not be an empty string ");
                }

                this.textIdentifier = value;
            }
        }

        public List<Teacher> Teachers
        {
            get { return new List<Teacher>(teachers); }
            private set { this.teachers = value; }
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