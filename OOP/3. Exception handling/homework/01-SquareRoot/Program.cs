using System;

class Program
{
    static void Main()
    {
        int inputNumber = int.Parse(Console.ReadLine());

        try
        {
            Console.WriteLine(Sqrt(inputNumber));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Good bye!");
        }
    }
    public static double Sqrt(double value)
    {
        if (value < 0)
        {
            throw new System.ArgumentOutOfRangeException("value", "Invalid number!");
        }

        return Math.Sqrt(value);
    }
}