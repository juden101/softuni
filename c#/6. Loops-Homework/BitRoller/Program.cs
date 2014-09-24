using System;

public class Program
{
    const int SIZE = 19;

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int pillarPosition = int.Parse(Console.ReadLine());
        int rolls = int.Parse(Console.ReadLine());

        for (int i = 0; i < rolls; i++)
        {
            n = RollBitsRight(n, pillarPosition);
        }

        Console.WriteLine(n);
    }

    private static int RollBitsRight(int n, int pillarPosition)
    {
        int result = 0;
        for (int pos = 0; pos < SIZE; pos++)
        {
            int bit = (n >> pos) & 1;
            if (pos == pillarPosition)
            {
                result = result | (bit << pos);
            }
            else
            {
                int newPos = RightPosition(pos);
                if (newPos == pillarPosition)
                {
                    newPos = RightPosition(newPos);
                }

                result = result | (bit << newPos);
            }
        }

        return result;
    }

    private static int RightPosition(int pos)
    {
        int newPos = pos - 1;

        if (newPos < 0)
        {
            newPos = SIZE - 1;
        }

        return newPos;
    }
}
