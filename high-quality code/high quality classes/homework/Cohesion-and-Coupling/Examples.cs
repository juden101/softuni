using System;

namespace CohesionAndCoupling
{
    class Examples
    {
        static void Main()
        {
            Console.WriteLine(FileExtension.GetFileExtension("example"));
            Console.WriteLine(FileExtension.GetFileExtension("example.pdf"));
            Console.WriteLine(FileExtension.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileName.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileName.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileName.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                DistanceTwoPoints.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                DistanceTwoPoints.CalcDistance3D(5, 2, -1, 3, -6, 4));

            try
            {
                Parallelepiped parallelepiped = new Parallelepiped(3, 4, 5);
                Console.WriteLine("Volume = {0:f2}", ParallelepipedVolume.CalcVolume(parallelepiped));
                Console.WriteLine("Diagonal XYZ = {0:f2}", ParallelepipedDiagonals.CalcDiagonalXYZ(parallelepiped));
                Console.WriteLine("Diagonal XY = {0:f2}", ParallelepipedDiagonals.CalcDiagonalXY(parallelepiped));
                Console.WriteLine("Diagonal XZ = {0:f2}", ParallelepipedDiagonals.CalcDiagonalXZ(parallelepiped));
                Console.WriteLine("Diagonal YZ = {0:f2}", ParallelepipedDiagonals.CalcDiagonalYZ(parallelepiped));
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }            
        }
    }
}
