using System;
class Program
{
    static void Main()
    {
        int n, f1, f2, fSum = 0;
        f1 = 0;
        f2 = 1;
        string fSequence = "";

        n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            if(i == 0 || i == 1)
            {
                fSequence += i + " ";
            }
            else
            {
                fSum = f1 + f2;
                f1 = f2;
                f2 = fSum;

                fSequence += fSum + " ";
            }
        }

        Console.WriteLine(fSequence);
    }
}