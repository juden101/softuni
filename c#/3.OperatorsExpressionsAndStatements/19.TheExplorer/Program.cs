using System;
using System.Text;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int center = n / 2;
        int diamondLeftPosition = center;
        int diamondRightPosition = center;
        bool goLeft = true;

        for (int i = 0; i < n; i++)
        {
            string line = new string('-', n);
            StringBuilder sb = new StringBuilder(line);
            sb[diamondLeftPosition] = '*';
            sb[diamondRightPosition] = '*';
            line = sb.ToString();

            Console.WriteLine(line);

            if (goLeft == true && diamondLeftPosition - 1 >= 0)
            {
                diamondLeftPosition--;
                diamondRightPosition++;
            }
            else
            {
                goLeft = false;

                if (diamondLeftPosition == center)
                {
                    goLeft = true;
                }

                diamondLeftPosition++;
                diamondRightPosition--;
            }
        }
    }
}