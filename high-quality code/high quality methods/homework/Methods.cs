using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        static string NumberToDigit(int number)
        {
            string numberToString = "";

            switch (number)
            {
                case 0: 
                    numberToString = "zero";
                    break;
                case 1: 
                    numberToString = "one"; 
                    break;
                case 2: 
                    numberToString = "two"; 
                    break;
                case 3: 
                    numberToString = "three";
                    break;
                case 4: 
                    numberToString = "four"; 
                    break;
                case 5:
                    numberToString = "five"; 
                    break;
                case 6:
                    numberToString = "six";
                    break;
                case 7:
                    numberToString = "seven"; 
                    break;
                case 8:
                    numberToString = "eight"; 
                    break;
                case 9: 
                    numberToString = "nine"; 
                    break;
                default: 
                    throw new ArgumentException("Invalid number!");
            }

            return numberToString;
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentOutOfRangeException("Elements length should be possitive.");
            }

            int maxFound = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxFound)
                {
                    maxFound = elements[i];
                }
            }

            return maxFound;
        }

        static void PrintAsNumber(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Wrong number format", "format");
            }
        }


        static double CalcDistance(double x1, double y1, double x2, double y2, 
            out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = false;
            isVertical = false;

            if ((y1 == y2) && (x1 == x2))
            {
                return 0;
            }

            if (y1 == y2)
            {
                isHorizontal = true;
            }

            if (x1 == x2)
            {
                isVertical = true;
            }

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            Console.WriteLine(NumberToDigit(5));
            Console.WriteLine(FindMax(1, -5, 2));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(CalcDistance(0, -1, 0, -1, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 3, 17), "From Sofia");
            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 3), "From Vidin, gamer, high results");

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
