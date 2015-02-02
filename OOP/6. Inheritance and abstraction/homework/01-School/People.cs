namespace School
{
    using System;

    public abstract class People
    {
        private string name;
        private string details;

        public People(string name, string details = null)
        {
            this.Name = name;
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