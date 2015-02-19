namespace CohesionAndCoupling
{
    public static class ParallelepipedVolume
    {
        public static double CalcVolume(Parallelepiped parallelepiped)
        {
            double volume = parallelepiped.Width * parallelepiped.Height * parallelepiped.Depth;
            return volume;
        }
    }
}
