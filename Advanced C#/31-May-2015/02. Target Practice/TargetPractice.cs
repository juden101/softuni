using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TargetPractice
{
    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split();
        int rows = int.Parse(dimensions[0]);
        int cols = int.Parse(dimensions[1]);

        string input = Console.ReadLine();
        Queue<char> inputQ = new Queue<char>(input);

        string[] shot = Console.ReadLine().Split();
        int shotRow = int.Parse(shot[0]);
        int shotCol = int.Parse(shot[1]);
        int shotRadius = int.Parse(shot[2]);

        char[,] matrix = new char[rows, cols];

        int position = -1;

        // fill
        for (int i = rows - 1; i >= 0; i--)
        {
            if (position < 0)
            {
                for (int j = cols - 1; j >= 0; j--)
                {
                    char currentChar = inputQ.Dequeue();
                    matrix[i, j] = currentChar;
                    inputQ.Enqueue(currentChar);
                }

                position = 1;
            }
            else if (position > 0)
            {
                for (int j = 0; j < cols; j++)
                {
                    char currentChar = inputQ.Dequeue();
                    matrix[i, j] = currentChar;
                    inputQ.Enqueue(currentChar);
                }

                position = -1;
            }
        }

        // shot
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int deltaRow = i - shotRow;
                int deltaCol = j - shotCol;

                bool isInRadius = deltaRow * deltaRow + deltaCol * deltaCol <= shotRadius * shotRadius;

                if (isInRadius)
                {
                    matrix[i, j] = ' ';
                }
            }
        }

        // fall down
        for (int i = rows - 1; i >= 0; i--)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] != ' ')
                {
                    continue;
                }

                int currentRow = i - 1;

                while(currentRow >= 0)
                {
                    if (matrix[currentRow, j] != ' ')
                    {
                        matrix[i, j] = matrix[currentRow, j];
                        matrix[currentRow, j] = ' ';
                        break;
                    }

                    currentRow--;
                }
            }
        }

        // print
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j]);
            }

            Console.WriteLine();
        }
    }
}