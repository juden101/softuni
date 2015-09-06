namespace StacksAndQueuesHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ReverseNumbersWithAStack
    {
        static void Main()
        {
            string input = Console.ReadLine();

            try
            {
                IEnumerable<int> rawNumbers = input.Split(' ').Select(int.Parse);
                Stack<int> numbers = new Stack<int>(rawNumbers);

                while (numbers.Count > 0)
                {
                    int number = numbers.Pop();
                    Console.Write("{0} ", number);
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Incorrect input!");
            }
            
            Console.WriteLine();
        }
    }
}