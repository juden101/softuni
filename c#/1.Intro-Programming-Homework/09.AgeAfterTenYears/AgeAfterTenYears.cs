using System;

class AgeAfterTenYears
{
    static void Main()
    {
        DateTime currentDate = DateTime.Now;
        Console.Write("Please enter your birthday: ");
        byte age = byte.Parse(Console.ReadLine());
        
        if(age < 1 || age > 100)
        {
            Console.WriteLine("Invalid age");
        }
        else
        {
            Console.WriteLine("Your age now is: " + age);
            Console.WriteLine("Your age after 10 years will be: " + (age + 10));
        }
    }
}
