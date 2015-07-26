using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    public class CalculateExpression
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            try
            {
                ShuntingYard shuntingYard = new ShuntingYard();
                string[] elements = shuntingYard.GetExpressionElements(input);

                Queue<string> postfixExpression = shuntingYard.ConvertToPostfix(elements);
                Console.WriteLine("Postfix expression: {0}", string.Join(" ", postfixExpression));

                double result = shuntingYard.CalculatePostfixExpression(postfixExpression);
                Console.WriteLine("Result: {0}", result);
            }
            catch(ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}