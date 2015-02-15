using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string FacultyNumber { get; set; }
    public string Phone { get; set; }
    public IList<int> Marks { get; set; }
    public string AllMarks { get; set; }
    public int GroupNumber { get; set; }
    public string Email { get; set; }
    public string GroupName { get; set; }

    public Student(string firstName, string lastName, int age, string facultyNumber, string phone, IList<int> marks, int groupNumber, string email, string groupName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.FacultyNumber = facultyNumber;
        this.Phone = phone;
        this.Marks = marks;
        this.GroupNumber = groupNumber;
        this.Email = email;
        this.GroupName = groupName;
    }

    public override string ToString()
    {
        string result =
            String.Format("Student: {0} {1}, Age: {2}, Factualy number: {3}, Phone: {4}, Marks: ({5}), Group number: {6}, Email: {7}, Group name: {8}",
            this.FirstName, this.LastName, this.Age, this.FacultyNumber, this.Phone, String.Join(", ", this.Marks), this.GroupNumber, this.Email, this.GroupName);

        return result;
    }
}