using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        BigInteger[] array = Console.ReadLine()
            .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(BigInteger.Parse)
            .ToArray();
        
        int index = 0;
        string command;

        while ((command = Console.ReadLine()) != "stop")
        {
            string[] operations = command.Split();
            int offset = int.Parse(operations[0]) % array.Length;
            string operation = operations[1];
            int operand = int.Parse(operations[2]);

            if (offset < 0)
            {
                offset += array.Length;
            }

            index = (index + offset) % array.Length;

            switch (operation)
            {
                case "&":
                    array[index] &= operand;
                    break;
                case "|":
                    array[index] |= operand;
                    break;
                case "^":
                    array[index] ^= operand;
                    break;
                case "+":
                    array[index] += operand;
                    break;
                case "-":
                    array[index] -= operand;
                    break;
                case "*":
                    array[index] *= operand;
                    break;
                case "/":
                    array[index] /= operand;
                    break;
            }

            if (array[index] < 0)
            {
                array[index] = 0;
            }
        }

        Console.WriteLine("[{0}]", string.Join(", ", array));
    }
}