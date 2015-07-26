namespace homework
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ShuntingYard
    {
        private Regex wordRegex = new Regex("[a-zA-Z]+", RegexOptions.IgnoreCase);
        private Regex numRegex = new Regex("-?[0-9]+", RegexOptions.IgnoreCase);
        private Regex floatingNumRegex = new Regex("-?[0-9]+\\.[0-9]+");

        public Queue<string> ConvertToPostfix(string[] elements)
        {
            Queue<string> outputQueue = new Queue<string>();
            Stack<string> operationStack = new Stack<string>();

            foreach (string element in elements)
            {
                if (numRegex.IsMatch(element))
                {
                    outputQueue.Enqueue(element);
                }
                else if (IsOperator(element))
                {
                    if (operationStack.Count == 0)
                    {
                        operationStack.Push(element);
                    }
                    else
                    {
                        while (operationStack.Count > 0 &&
                            IsOperator(element) &&
                            IsOperator(operationStack.Peek()) &&
                            CheckOperatorPrecedence(operationStack.Peek(), element) >= 0)
                        {
                            string topOperatorInStack = operationStack.Pop();
                            outputQueue.Enqueue(topOperatorInStack);
                        }

                        operationStack.Push(element);
                    }
                }
                else if (element == "(")
                {
                    operationStack.Push(element);
                }
                else if (element == ")")
                {
                    while (operationStack.Count > 0 &&
                        operationStack.Peek() != "(")
                    {
                        string topOperatorInStack = operationStack.Pop();
                        outputQueue.Enqueue(topOperatorInStack);
                    }

                    if (operationStack.Count == 0 || operationStack.Peek() != "(")
                    {
                        throw new ArgumentException("The expression is invalid.");
                    }

                    operationStack.Pop();
                }
                else
                {
                    throw new ArgumentException("The expression is invalid.");
                }
            }

            while (operationStack.Count > 0)
            {
                string topOperatorInStack = operationStack.Pop();

                if (!IsOperator(topOperatorInStack))
                {
                    throw new ArgumentException("The expression is invalid");
                }

                outputQueue.Enqueue(topOperatorInStack);
            }

            return outputQueue;
        }

        public double CalculatePostfixExpression(Queue<string> postfixExpression)
        {
            Stack<double> operationStack = new Stack<double>();

            while (postfixExpression.Count > 0)
            {
                string element = postfixExpression.Dequeue();

                if (numRegex.IsMatch(element) || floatingNumRegex.IsMatch(element))
                {
                    double number = double.Parse(element);
                    operationStack.Push(number);
                }
                else if (IsOperator(element))
                {
                    try
                    {
                        double secondNumber = operationStack.Pop();
                        double firstNumber = operationStack.Pop();
                        double result = 0;

                        switch (element)
                        {
                            case "+":
                                result = firstNumber + secondNumber;
                                break;
                            case "-":
                                result = firstNumber - secondNumber;
                                break;
                            case "*":
                                result = firstNumber * secondNumber;
                                break;
                            case "/":
                                result = firstNumber / secondNumber;
                                break;
                            default:
                                throw new ArgumentException("The expression is invalid.");
                        }

                        operationStack.Push(result);
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException("The expression is invalid.");
                    }
                }
                else
                {
                    throw new ArgumentException("The expression is invalid.");
                }
            }

            if (operationStack.Count != 1)
            {
                throw new ArgumentException("The expression is invalid.");
            }

            return operationStack.Pop();
        }

        private bool IsOperator(string element)
        {
            if (element == "-" ||
                element == "+" ||
                element == "/" ||
                element == "*")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int CheckOperatorPrecedence(string first, string second)
        {
            if ((first == "-" || first == "+") &&
                (second == "*" || second == "/"))
            {
                return -1;
            }
            else if ((second == "-" || second == "+") &&
                (first == "*" || first == "/"))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public string[] GetExpressionElements(string input)
        {
            Queue<string> output = new Queue<string>();
            string currentExpression = "";

            for (int index = 0; index < input.Length; index++)
            {
                if (wordRegex.IsMatch(input[index].ToString()))
                {
                    currentExpression += input[index];
                }
                else if (numRegex.IsMatch(input[index].ToString()) ||
                    input[index] == '.' ||
                    (input[index] == '-' &&
                    index + 1 < input.Length &&
                    numRegex.IsMatch(input[index + 1].ToString())))
                {
                    currentExpression += input[index];
                }
                else if (currentExpression.Length > 0)
                {
                    output.Enqueue(currentExpression);
                    currentExpression = "";
                    index--;
                }
                else
                {
                    if (input[index] != ' ')
                    {
                        output.Enqueue(input[index].ToString());
                    }
                }
            }

            if (currentExpression.Length > 0)
            {
                output.Enqueue(currentExpression);
            }

            return output.ToArray();
        }
    }
}