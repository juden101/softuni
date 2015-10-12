using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static int playerX = 0;
    public static int playerY = 0;

    static void Main()
    {
        int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = dimensions[0];
        int cols = dimensions[1];

        char[,] matrix = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            char[] line = Console.ReadLine().ToCharArray();

            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = line[j];

                if (line[j] == 'P')
                {
                    playerX = i;
                    playerY = j;
                }
            }
        }

        char[] directions = Console.ReadLine().ToCharArray();

        foreach (char direction in directions)
        {
            matrix[playerX, playerY] = '.';
            
            try
            {
                switch (direction)
                {
                    case 'L':
                        if (matrix[playerX, playerY - 1] == 'B')
                        {
                            playerY--;
                            throw new ArgumentException();
                        }

                        matrix[playerX, playerY - 1] = 'P';
                        playerY--;

                        break;
                    case 'R':
                        if (matrix[playerX, playerY + 1] == 'B')
                        {
                            playerY++;
                            throw new ArgumentException();
                        }

                        matrix[playerX, playerY + 1] = 'P';
                        playerY++;

                        break;
                    case 'U':
                        if (matrix[playerX - 1, playerY] == 'B')
                        {
                            playerX--;
                            throw new ArgumentException();
                        }

                        matrix[playerX - 1, playerY] = 'P';
                        playerX--;

                        break;
                    case 'D':
                        if (matrix[playerX + 1, playerY] == 'B')
                        {
                            playerX++;
                            throw new ArgumentException();
                        }

                        matrix[playerX + 1, playerY] = 'P';
                        playerX++;

                        break;
                }

                BreedRabbits(matrix);
            }
            catch (IndexOutOfRangeException e)
            {
                // win
                
                try
                {
                    BreedRabbits(matrix);
                }
                catch (Exception ex) { }

                PrintMatrix(matrix);
                Console.WriteLine("won: {0} {1}", playerX, playerY);

                break;
            }
            catch (ArgumentException e)
            {
                // dead
				
                try
                {
                    BreedRabbits(matrix);
                }
                catch (Exception ex) { }
				
                PrintMatrix(matrix);
                Console.WriteLine("dead: {0} {1}", playerX, playerY);

                break;
            }
            catch (InvalidOperationException e)
            {
                // dead
				
                PrintMatrix(matrix);
                Console.WriteLine("dead: {0} {1}", playerX, playerY);

                break;
            }
        }
    }

    private static bool IsCollision(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 'B' && playerX == i && playerY == j)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static void BreedRabbits(char[,] matrix)
    {
        List<Coords> coords = new List<Coords>();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] == 'B')
                {
                    coords.Add(new Coords() { X = i, Y = j });
                }
            }
        }

        foreach (Coords coord in coords)
        {
            // left
            try
            {
                matrix[coord.X, coord.Y - 1] = 'B';
            }
            catch (IndexOutOfRangeException e) { }


            // right
            try
            {
                matrix[coord.X, coord.Y + 1] = 'B';
            }
            catch (IndexOutOfRangeException e) { }

            // up
            try
            {
                matrix[coord.X - 1, coord.Y] = 'B';
            }
            catch (IndexOutOfRangeException e) { }

            // down
            try
            {
                matrix[coord.X + 1, coord.Y] = 'B';
            }
            catch (IndexOutOfRangeException e) { }
        }

        if (IsCollision(matrix))
        {
            throw new InvalidOperationException();
        }
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j]);
            }

            Console.WriteLine();
        }
    }
}

class Coords
{
    public int X { get; set; }
    public int Y { get; set; }
}