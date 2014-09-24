using System;

class Program
{
    static void Main()
    {
        bool isSubset = false;
        string[] numbers = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); ;
        
        int a = int.Parse(numbers[0]);
        int b = int.Parse(numbers[1]);
        int c = int.Parse(numbers[2]);
        int d = int.Parse(numbers[3]);
        int e = int.Parse(numbers[4]);
        
        if(a + b == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} = 0", a, b);
        }
        if (a + c == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} = 0", a, c);
        }
        if (a + d == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} = 0", a, d);
        }
        if (a + e == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} = 0", a, e);
        }
        if (b + c == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} = 0", b, c);
        }
        if (b + d == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} = 0", b, d);
        }
        if (b + e == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} = 0", b, e);
        }
        if (c + d == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} = 0", c, d);
        }
        if (c + e == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} = 0", c, e);
        }
        if (a + b + c == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} + {2} = 0", a, b, c);
        }
        if (a + b + d == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} + {2} = 0", a, b, d);
        }
        if (a + b + e == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} + {2} = 0", a, b, e);
        }
        if (b + c + d == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} + {2} = 0", b, c, d);
        }
        if (b + c + e == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} + {2} = 0", b, c, e);
        }
        if (b + d + e == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} + {2} = 0", b, d, e);
        }
        if (c + d + e == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} + {2} = 0", c, d, e);
        }
        if (a + b + c + d == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, b, c, d);
        }
        if (a + b + c + e == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, b, c, e);
        }
        if (a + b + d + e == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, b, d, e);
        }
        if (a + c + d + e == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, c, d, e);
        }
        if(a + b + c + d + e == 0)
        {
            isSubset = true;
            Console.WriteLine("{0} + {1} + {2} + {3} + {4} = 0", a, b, c, d, e);
        }

        if(!isSubset)
        {
            Console.WriteLine("no zero subset");
        }
    }
}