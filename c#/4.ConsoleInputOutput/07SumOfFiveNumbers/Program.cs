using System;

class Program
{
    static void Main()
    {
        string sequence;
        double sum = 0;

        Console.Write("numbers: ");
        sequence = Console.ReadLine();

        string[] numbers = sequence.Split(' ');
        for (int i = 0; i < 5; i++)
        {
            sum += double.Parse(numbers[i].ToString());
        }

        Console.WriteLine("sum = {0}", sum);
    }
}