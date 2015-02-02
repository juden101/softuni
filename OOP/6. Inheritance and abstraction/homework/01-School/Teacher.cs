namespace School
{
    using System;
    using System.Collections.Generic;

    public class Teacher : People
    {
        private List<Disciplines> disciplines;

        public Teacher(string name, List<Disciplines> disciplines, string details = null)
            : base(name, details)
        {
            this.Disciplines = disciplines;
        }

        public List<Disciplines> Disciplines
        {
            get { return new List<Disciplines>(this.disciplines); }
            private set { this.disciplines = value; }
        }


    }
}