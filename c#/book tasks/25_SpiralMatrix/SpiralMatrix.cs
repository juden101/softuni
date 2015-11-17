using System;

public class SpiralMatrix
{
    public static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        
        matrix = RotateMatrix(matrix, n);
        PrintMatrix(matrix, n);
    }

    private static int[,] RotateMatrix(int[,] matrix, int n)
    {
        double matrixLength = (int)Math.Pow(n, 2);
        int x = n - 1;
        int y = 0;
        Directions direction = Directions.Down;

        for (int i = 1; i <= matrixLength; i++)
        {
            if (direction == Directions.Down && (x > n - 1 || matrix[y, x] != 0))
            {
                direction = Directions.Left;
                x--;
                y++;
            }
            else if (direction == Directions.Left && (y > n - 1 || matrix[y, x] != 0))
            {
                direction = Directions.Up;
                y--;
                x--;
            }
            else if (direction == Directions.Up && (x < 0 || matrix[y, x] != 0))
            {
                direction = Directions.Right;
                x++;
                y--;
            }
            else if (direction == Directions.Right && (y < 0 || matrix[y, x] != 0))
            {
                direction = Directions.Down;
                y++;
                x++;
            }

            matrix[y, x] = i;

            switch (direction)
            {
                case Directions.Down:
                    x++;
                    break;
                case Directions.Left:
                    y++;
                    break;
                case Directions.Up:
                    x--;
                    break;
                case Directions.Right:
                    y--;
                    break;
            }
        }

        return matrix;
    }

    private static void PrintMatrix(int[,] matrix, int n)
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0,3}", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }
}