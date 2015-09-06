namespace homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RideTheHorse
    {
        private static int[,] field;
        private static int width;
        private static int height;

        public static void Main()
        {
            width = int.Parse(Console.ReadLine());
            height = int.Parse(Console.ReadLine());
            field = new int[width, height];
            
            int startX = int.Parse(Console.ReadLine());
            int startY = int.Parse(Console.ReadLine());
            var startCell = new Cell(startX, startY);

            var moveQueue = new Queue<Cell>();
            moveQueue.Enqueue(startCell);
            while (moveQueue.Count > 0)
            {
                var currentCell = moveQueue.Dequeue();
                field[currentCell.X, currentCell.Y] = currentCell.Value;

                TryDirection(currentCell, moveQueue, -2, 1);
                TryDirection(currentCell, moveQueue, -1, 2);
                TryDirection(currentCell, moveQueue, 1, 2);
                TryDirection(currentCell, moveQueue, 2, 1);
                TryDirection(currentCell, moveQueue, 2, -1);
                TryDirection(currentCell, moveQueue, 1, -2);
                TryDirection(currentCell, moveQueue, -1, -2);
                TryDirection(currentCell, moveQueue, -2, -1);
            }

            PrintNeededCol();
        }

        private static void TryDirection(Cell currentCell, Queue<Cell> moveQueue, int x, int y)
        {
            var newX = currentCell.X + x;
            var newY = currentCell.Y + y;

            if (newX >= 0 &&
                newX < width &&
                newY >= 0 &&
                newY < height &&
                field[newX, newY] == 0)
            {
                moveQueue.Enqueue(new Cell(newX, newY, currentCell.Value + 1));
            }
        }

        private static void PrintNeededCol()
        {
            Console.WriteLine();

            for (int x = 0; x < width; x++)
            {
                Console.WriteLine(field[x, height / 2]);
            }
        }
    }
}