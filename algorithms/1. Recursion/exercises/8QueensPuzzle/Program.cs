using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueensPuzzle
{
    public class EightQueens
    {
        public static int solutionsFound = 0;
        private const int Size = 8;
        private static bool[,] chessboard = new bool[Size, Size];

        private static bool[] attackedCols = new bool[Size];
        private static bool[] attackedLeftDiagonals = new bool[Size * 2];
        private static bool[] attackedRightDiagonals = new bool[Size * 2];

        public static void Main()
        {
            PutQueens(0);
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (chessboard[row, col] == true)
                    {
                        Console.Write("Q");
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            solutionsFound++;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            bool positionOccupied =
                attackedCols[col] ||
                attackedLeftDiagonals[col - row + Size] ||
                attackedRightDiagonals[col + row];

            return !positionOccupied;
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            attackedCols[col] = true;
            attackedLeftDiagonals[col - row + Size] = true;
            attackedRightDiagonals[col + row] = true;
            chessboard[row, col] = true;
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            attackedCols[col] = false;
            attackedLeftDiagonals[col - row + Size] = false;
            attackedRightDiagonals[col + row] = false;
            chessboard[row, col] = false;
        }

        private static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < Size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }
    }
}