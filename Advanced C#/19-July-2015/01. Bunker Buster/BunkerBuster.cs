using System;

class Program
{
    static void Main()
    {
        string matrixLine = Console.ReadLine();
        int n = int.Parse(matrixLine.Split(' ')[0]);
        int m = int.Parse(matrixLine.Split(' ')[1]);

        int[,] matrix = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            string[] cells = Console.ReadLine().Split(' ');

            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = int.Parse(cells[j]);
            }
        }

        string bombLine;
        while ((bombLine = Console.ReadLine()) != "cease fire!")
        {
            string[] bombValues = bombLine.Split(' ');

            int row = int.Parse(bombValues[0]);
            int col = int.Parse(bombValues[1]);
            int bomb = (int)char.Parse(bombValues[2]);

            matrix[row, col] -= bomb;
            
            int adjacentDamage = (int)Math.Ceiling(bomb / 2.0d);

            if (row - 1 >= 0 && col - 1 >= 0)
            {
                matrix[row - 1, col - 1] -= adjacentDamage;
            }

            if (row - 1 >= 0)
            {
                matrix[row - 1, col] -= adjacentDamage;
            }

            if (row - 1 >= 0 && col + 1 < m)
            {
                matrix[row - 1, col + 1] -= adjacentDamage;
            }

            if (col - 1 >= 0)
            {
                matrix[row, col - 1] -= adjacentDamage;
            }

            if (col + 1 < m)
            {
                matrix[row, col + 1] -= adjacentDamage;
            }

            if (row + 1 < n && col - 1 >= 0)
            {
                matrix[row + 1, col - 1] -= adjacentDamage;
            }

            if (row + 1 < n)
            {
                matrix[row + 1, col] -= adjacentDamage;
            }

            if (row + 1 < n && col + 1 < m)
            {
                matrix[row + 1, col + 1] -= adjacentDamage;
            }
        }

        int destroyed = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] <= 0)
                {
                    destroyed++;
                }
            }
        }

        Console.WriteLine("Destroyed bunkers: {0}", destroyed);
        Console.WriteLine("Damage done: {0:0.0} %", (double)destroyed / (n * m) * 100);
    }
}