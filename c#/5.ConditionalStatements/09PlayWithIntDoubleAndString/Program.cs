using System;

class Program
{
    static void Main()
    {
        int type;

        Console.WriteLine("1 --> int\n2 --> double\n3 --> string");
        Console.Write("Please choose a type: ");
        type = int.Parse(Console.ReadLine());

        switch (type)
        {
            case 1:
                Console.Write("Please enter a int: ");

                int intInput = int.Parse(Console.ReadLine());
                Console.WriteLine(++intInput);

                break;
            case 2:
                Console.Write("Please enter a double: ");

                double doubleInput = double.Parse(Console.ReadLine());
                Console.WriteLine(++doubleInput);

                break;
            case 3:
                Console.Write("Please enter a string: ");

                string stringInput = Console.ReadLine();
                Console.WriteLine(stringInput + "*");

                break;
            default:
                break;
        }
    }
}