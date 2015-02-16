using System;
using System.Collections.Generic;

class Test
{
    static void Main()
    {
        Customer Ivan = new Customer("Ivan", "Petrov", "Goshov", 3, "Sofia, Mladost", "+359-897-687-52", "ivan@gmail.com", new List<Payment>() { new Payment("Lenovo", 533), new Payment("Samsung", 789), }, CustomerType.Golden);
        Customer Petar = new Customer("Petar", "Goshov", "Ivanov", 2, "Sofia, Lulin", "+359-897-534-59", "petar@gmail.com", new List<Payment>() { new Payment("Acer", 533), new Payment("MSI", 789), }, CustomerType.OneTime);
        Customer Ivan4o = new Customer("Ivan", "Petrov", "Goshov", 1, "Sofia, Iztok", "+359-897-687-49", "ivan4o@gmail.com", new List<Payment>() { new Payment("Asus", 533), new Payment("HP", 789), }, CustomerType.Diamond);
        Customer IvanCopy = (Customer)Ivan.Clone();

        Console.WriteLine(Ivan + "\n");

        Console.WriteLine(Ivan.Equals(Petar));
        Console.WriteLine(Ivan.Equals(Ivan4o));
        Console.WriteLine(Ivan.Equals(IvanCopy) + "\n");

        Console.WriteLine(Ivan.CompareTo(IvanCopy));
        Console.WriteLine(Ivan.CompareTo(Ivan4o));
    }
}