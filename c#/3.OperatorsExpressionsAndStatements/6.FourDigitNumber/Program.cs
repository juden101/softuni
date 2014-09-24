using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.Write("Please enter number: ");
        int number = int.Parse(Console.ReadLine());

        int fourthNumber = number % 10;
        int thirdNumber = (number / 10) % 10;
        int secondNumber = (number / 100) % 10;
        int firstNumber = (number / 1000) % 10;

        Console.WriteLine("Sums of digits: {0}", firstNumber + secondNumber + thirdNumber + fourthNumber);
        Console.WriteLine("Reversed number: {0}{1}{2}{3}", fourthNumber, thirdNumber, secondNumber, firstNumber);
        Console.WriteLine("Last digit in front: {0}{1}{2}{3}", fourthNumber, firstNumber, secondNumber, thirdNumber);
        Console.WriteLine("second and third digits exchanged: {0}{1}{2}{3}", firstNumber, thirdNumber, secondNumber, fourthNumber);
    }
}