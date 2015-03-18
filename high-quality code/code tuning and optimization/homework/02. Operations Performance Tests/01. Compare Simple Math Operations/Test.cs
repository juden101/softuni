using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CompareSimpleMathOperations
{
    static void Main()
    {
        int length = 100000000;

        Console.WriteLine("== Adding ==");
        DisplayExecutionTime(() =>
        {
            int a = 0;
            for (int i = 0; i < length; i++)
            {
                a += i;
            }
            Console.Write("int: ");
        });

        DisplayExecutionTime(() =>
        {
            long a = 0l;
            for (int i = 0; i < length; i++)
            {
                a += i;
            }
            Console.Write("long: ");
        });

        DisplayExecutionTime(() =>
        {
            float a = 0f;
            for (int i = 0; i < length; i++)
            {
                a += i;
            }
            Console.Write("float: ");
        });

        DisplayExecutionTime(() =>
        {
            double a = 0d;
            for (int i = 0; i < length; i++)
            {
                a += i;
            }
            Console.Write("double: ");
        });

        DisplayExecutionTime(() =>
        {
            decimal a = 0m;
            for (int i = 0; i < length; i++)
            {
                a += i;
            }
            Console.Write("decimal: ");
        });
        
        Console.WriteLine("\n== Subtracting ==");
        DisplayExecutionTime(() =>
        {
            int a = 0;
            for (int i = 0; i < length; i++)
            {
                a -= i;
            }
            Console.Write("int: ");
        });

        DisplayExecutionTime(() =>
        {
            long a = 0l;
            for (int i = 0; i < length; i++)
            {
                a -= i;
            }
            Console.Write("long: ");
        });

        DisplayExecutionTime(() =>
        {
            float a = 0f;
            for (int i = 0; i < length; i++)
            {
                a -= i;
            }
            Console.Write("float: ");
        });

        DisplayExecutionTime(() =>
        {
            double a = 0d;
            for (int i = 0; i < length; i++)
            {
                a -= i;
            }
            Console.Write("double: ");
        });
        
        DisplayExecutionTime(() =>
         {
             decimal a = 0m;
             for (int i = 0; i < length; i++)
             {
                 a -= i;
             }
             Console.Write("decimal: ");
         });
        
        Console.WriteLine("\n== Incrementing ==");
        DisplayExecutionTime(() =>
        {
            int a = 0;
            for (int i = 0; i < length; i++)
            {
                a++;
            }
            Console.Write("int: ");
        });

        DisplayExecutionTime(() =>
        {
            long a = 0l;
            for (int i = 0; i < length; i++)
            {
                a++;
            }
            Console.Write("long: ");
        });

        DisplayExecutionTime(() =>
        {
            float a = 0f;
            for (int i = 0; i < length; i++)
            {
                a++;
            }
            Console.Write("float: ");
        });

        DisplayExecutionTime(() =>
        {
            double a = 0d;
            for (int i = 0; i < length; i++)
            {
                a++;
            }
            Console.Write("double: ");
        });

        DisplayExecutionTime(() =>
        {
            decimal a = 0m;
            for (int i = 0; i < length; i++)
            {
                a++;
            }
            Console.Write("decimal: ");
        });

        Console.WriteLine("\n== Multiplying ==");
        DisplayExecutionTime(() =>
        {
            int a = 1;
            for (int i = 0; i < length; i++)
            {
                a *= 1;
            }
            Console.Write("int: ");
        });

        DisplayExecutionTime(() =>
        {
            long a = 1l;
            for (int i = 0; i < length; i++)
            {
                a *= 1;
            }
            Console.Write("long: ");
        });

        DisplayExecutionTime(() =>
        {
            float a = 1f;
            for (int i = 0; i < length; i++)
            {
                a *= 1;
            }
            Console.Write("float: ");
        });

        DisplayExecutionTime(() =>
        {
            double a = 1d;
            for (int i = 0; i < length; i++)
            {
                a *= 1;
            }
            Console.Write("double: ");
        });

        DisplayExecutionTime(() =>
        {
            decimal a = 1m;
            for (int i = 0; i < length; i++)
            {
                a *= 1;
            }
            Console.Write("decimal: ");
        });

        Console.WriteLine("\n== Dividing ==");
        DisplayExecutionTime(() =>
        {
            int a = 1;
            for (int i = 0; i < length; i++)
            {
                a /= 1;
            }
            Console.Write("int: ");
        });

        DisplayExecutionTime(() =>
        {
            long a = 1l;
            for (int i = 0; i < length; i++)
            {
                a /= 1;
            }
            Console.Write("long: ");
        });

        DisplayExecutionTime(() =>
        {
            float a = 1f;
            for (int i = 0; i < length; i++)
            {
                a /= 1;
            }
            Console.Write("float: ");
        });

        DisplayExecutionTime(() =>
        {
            double a = 1d;
            for (int i = 0; i < length; i++)
            {
                a /= 1;
            }
            Console.Write("double: ");
        });

        DisplayExecutionTime(() =>
        {
            decimal a = 1m;
            for (int i = 0; i < length; i++)
            {
                a /= 1;
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
