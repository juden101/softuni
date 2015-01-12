﻿using System;
using System.Collections.Generic;

namespace Geometry
{
    class Path
    {
        private List<Point> points = new List<Point>();

        static void Main()
        {
            Point p1 = new Point(1, 2, 3);
            Point p2 = new Point(3.4, 4.66, 5.55);

            Path path = new Path(p1, p2, Point.StartPoint);
            Console.WriteLine("Save path: {0}", path);
            Storage.SavePathInFile("path.txt", path);
            Path loadPath = Storage.LoadPathOfFile("path.txt");
            Console.WriteLine("Load path: {0}", loadPath);
        }

        public Path(params Point[] points)
        {
            if (points.Length > 0)
            {
                this.points.AddRange(points);
            }
        }

        public void AddPoint(Point point)
        {
            this.points.Add(point);
        }

        public override string ToString()
        {
            return string.Join(" ", this.points);
        }
    }
}
