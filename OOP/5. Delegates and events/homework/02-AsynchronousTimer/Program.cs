using System;

class Program
{
    static void Main()
    {
        AsyncTimer timer1 = new AsyncTimer(Task1, 1000, 10);
        timer1.Start();

        AsyncTimer timer2 = new AsyncTimer(Task2, 500, 20);
        timer2.Start();
    }

    public static void Task1(string str)
    {
        Console.WriteLine(str);
    }

    public static void Task2(string str)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(str);
        Console.ForegroundColor = ConsoleColor.White;
    }
    
}