using System;

class Program
{
    static void Main(string[] args)
    {
        var student = new Student("Pesho", 18);
        student.Name = "Gosho";
        student.Age = 25;
    }
}