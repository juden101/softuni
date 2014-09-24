using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingFloats
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter first number: ");
            double firstNumber = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number: ");
            double secondNumber = double.Parse(Console.ReadLine());

            double eps = 0.000001;

            if(firstNumber > secondNumber)
            {
                if(firstNumber - secondNumber > eps)
                {
                    Console.WriteLine(false);
                }
                else
                {
                    Console.WriteLine(true);
                }
            }
            else if(secondNumber > firstNumber)
            {
                if (secondNumber - firstNumber > eps)
                {
                    Console.WriteLine(false);
                }
                else
                {
                    Console.WriteLine(true);
                }
            }
        }
    }
}
