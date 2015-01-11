﻿using System;

namespace Geometry
{
    public static class DistanceCalcolator
    {
        static void Main()
        {
            double distance = DistanceCalcolator.CalculateDistance(new Point(1, 2, 3), new Point(3.4, 4.66, 5.55));
            Console.WriteLine(distance);
        }

        public static double CalculateDistance(Point p1, Point p2)
        {
            double deltaX = p1.X - p2.X;
            double deltaY = p1.Y - p2.Y;
            double deltaZ = p1.Z - p2.Z;
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
            return distance;
        }

    }
}