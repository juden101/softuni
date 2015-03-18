using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CompareAdvancedMathOperations
{
    static void Main()
    {
        int length = 10000000;

        Console.WriteLine("== Square root ==");
        DisplayExecutionTime(() =>
        {
            float a = 0f;
            for (int i = 0; i < length; i++)
            {
                a = (float)Math.Sqrt(length);
            }
            Console.Write("float: ");
        });

        DisplayExecutionTime(() =>
        {
            double a = 0f;
            for (int i = 0; i < length; i++)
            {
                a = (double)Math.Sqrt(length);
            }
            Console.Write("double: ");
        });

        DisplayExecutionTime(() =>
        {
            decimal a = 0m;
            for (int i = 0; i < length; i++)
            {
                a = (decimal)Math.Sqrt(length);
            }
            Console.Write("decimal: ");
        });

        Console.WriteLine("\n== Natural logarithm ==");
        DisplayExecutionTime(() =>
        {
            float a = 0f;
            for (int i = 0; i < length; i++)
            {
                a = (float)Math.Log(length);
            }
            Console.Write("float: ");
        });

        DisplayExecutionTime(() =>
        {
            double a = 0f;
            for (int i = 0; i < length; i++)
            {
                a = (double)Math.Log(length);
            }
            Console.Write("double: ");
        });

        DisplayExecutionTime(() =>
        {
            decimal a = 0m;
            for (int i = 0; i < length; i++)
            {
                a = (decimal)Math.Log(length);
            }
            Console.Write("decimal: ");
        });

        Console.WriteLine("\n== Sinus ==");
        DisplayExecutionTime(() =>
        {
            float a = 0f;
            for (int i = 0; i < length; i++)
            {
                a = (float)Math.Sin(length);
            }
            Console.Write("float: ");
        });

        DisplayExecutionTime(() =>
        {
            double a = 0f;
            for (int i = 0; i < length; i++)
            {
                a = (double)Math.Sin(length);
            }
            Console.Write("double: ");
        });

        DisplayExecutionTime(() =>
        {
            decimal a = 0m;
            for (int i = 0; i < length; i++)
            {
                a = (decimal)Math.Sin(length);
            }
            Console.Write("decimal: ");
        });
    }

    static void DisplayExecutionTime(Action action)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        action();
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed);
    }
}
