using System;

public class StudentTest
{
    static void Main()
    {
        var firstStudent = new Student("Ivan", "Vasilev", "Zahariev", "Software Engineering", "Bachelor", "SoftUni", "izahariev96@gmail.com", "+359-87-123-456");
        Console.WriteLine(firstStudent);

        var secondStudent = new Student("Ivan", "Vasilev", "Zahariev");
        Console.WriteLine(secondStudent);

        var thirdStudent = new Student("Ivan", "Zahariev");
        Console.WriteLine(thirdStudent);

        var fourthStudent = new Student("Ivan", "Zahariev", "izahariev96@gmail.com", "+359-87-123-456");
        Console.WriteLine(fourthStudent);
    }
}