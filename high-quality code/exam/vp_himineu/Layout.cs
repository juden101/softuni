namespace VehicleParkSystem
{
    using System;

    public class Layout
    {
        private int sectors;
        private int placesPerSector;

        public Layout(int numberOfSectors, int placesPerSector)
        {
            this.Sectors = numberOfSectors;
            this.PlacesPerSector = placesPerSector;
        }

        public int Sectors
        {
            get
            {
                return this.sectors;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new DivideByZeroException("The number of places per sector must be positive.");
                }

                this.sectors = value;
            }
        }

        public int PlacesPerSector
        {
            get
            {
                return this.placesPerSector;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new DivideByZeroException("The number of sectors must be positive.");
                }

                this.placesPerSector = value;
            }
        }
    }
}