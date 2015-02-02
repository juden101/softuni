namespace School
{
    using System;

    public class Student : People
    {
        private int classNumber;

        public Student(string name, int classNumber, string detials = null)
            : base(name, detials)
        {
            this.ClassNumber = classNumber;
        }



        public int ClassNumber
        {
            get { return this.classNumber; }
            private set
            {
                if (value.ToString().Length < 6 || value.ToString().Contains("-"))
                {
                    throw new ArgumentOutOfRangeException("ID should be a 6 digit number");
                }

                this.classNumber = value;
            }
        }

    }
}