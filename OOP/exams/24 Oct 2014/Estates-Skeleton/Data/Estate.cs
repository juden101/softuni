namespace Estates.Data
{
    using System;

    using Interfaces;

    public class Estate : IEstate
    {
        private string name;
        private EstateType type;
        private double area;
        private string location;
        private bool isFurnished;

        public Estate(EstateType type)
        {
            this.Type = type;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public EstateType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public double Area
        {
            get
            {
                return this.area;
            }
            set
            {
                if(value < 0 || value > 10000)
                {
                    throw new ArgumentOutOfRangeException("Estate area should be between 0 and 10000");
                }

                this.area = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }

        public bool IsFurnished
        {
            get
            {
                return this.isFurnished;
            }
            set
            {
                this.isFurnished = value;
            }
        }
    }
}
