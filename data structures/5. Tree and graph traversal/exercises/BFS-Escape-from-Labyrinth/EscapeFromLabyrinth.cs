﻿using System;
using System.Collections.Generic;
using System.Text;

public class EscapeFromLabyrinth
{
    const char VisitedCell = 's';

    static int width = 9;
    static int height = 7;
    static char[,] labyrinth =
    {
        { '*', '*', '*', '*', '*', '*', '*', '*', '*' },
        { '*', '-', '-', '-', '-', '*', '*', '-', '-' },
        { '*', '*', '-', '*', '-', '-', '-', '-', '*' },
        { '*', '-', '-', '*', '-', '*', '-', '*', '*' },
        { '*', 's', '*', '-', '-', '*', '-', '*', '*' },
        { '*', '*', '-', '-', '-', '-', '-', '-', '*' },
        { '*', '*', '*', '*', '*', '*', '*', '-', '*' }
    };

    static string FindShortestPathToExit()
    {
        var queue = new Queue<Point>();
        var startPosition = FindStartPosition();

        if (startPosition == null)
        {
            return null;
        }

        queue.Enqueue(startPosition);

        while (queue.Count > 0)
        {
            var currentCell = queue.Dequeue();

            if (IsExit(currentCell))
            {
                return TracePathBack(currentCell);
            }

            TryDirection(queue, currentCell, "U", 0, -1);
            TryDirection(queue, currentCell, "R", +1, 0);
            TryDirection(queue, currentCell, "D", 0, +1);
            TryDirection(queue, currentCell, "L", -1, 0);
        }

        return null;
    }

    static Point FindStartPosition()
    {
        for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
                 if (labyrinth[y, x] == VisitedCell)
                 {
                     return new Point()
                     {
                         X = x,
                         Y = y
                     };
                 }
			}
		}

        return null;
    }

    static bool IsExit(Point currentCell)
    {
        bool isOnBoardX = currentCell.X == 0 || currentCell.X == width - 1;
        bool isOnBoardY = currentCell.Y == 0 || currentCell.X == height - 1;

        return isOnBoardX || isOnBoardY;
    }

    static void TryDirection(Queue<Point> queue, Point currentCell, string direction, int deltaX, int deltaY)
    {
        int newX = currentCell.X + deltaX;
        int newY = currentCell.Y + deltaY;

        if (newX >= 0 && newX < width &&
            newY >=0 && newY < height &&
            labyrinth[newY, newX] == '-')
        {
            labyrinth[newY, newX] = VisitedCell;

            var nextCell = new Point()
            {
                X = newX,
                Y = newY,
                Direction = direction,
                PreviousPoint = currentCell
            };

            queue.Enqueue(nextCell);
        }
    }

    static string TracePathBack(Point currentCell)
    {
        var path = new StringBuilder();

        while(currentCell.PreviousPoint != null)
        {
            path.Append(currentCell.Direction);
            currentCell = currentCell.PreviousPoint;
        }

        var pathReversed = new StringBuilder(path.Length);

        for (int i = path.Length - 1; i >= 0; i--)
		{
			 pathReversed.Append(path[i]);
		}

        return pathReversed.ToString();
    }

    static void ReadLabyrinth()
    {
        width = int.Parse(Console.ReadLine());
        height = int.Parse(Console.ReadLine());
        labyrinth = new char[height, width];

        for (int row = 0; row < height; row++)
        {
            
        }
    }

    public static void Main()
    {
        string shortestPathToExit = FindShortestPathToExit();

        if (shortestPathToExit == null)
        {
            Console.WriteLine("No exit!");
        }
        else if (shortestPathToExit == "")
        {
            Console.WriteLine("Start is at the exit.");
        }
        else
        {
            Console.WriteLine("Shortest exit: {0}", shortestPathToExit);
        }
    }
}