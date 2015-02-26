namespace Estates.Data
{
    using System;

    using Interfaces;

    public class House : Estate, IHouse
    {
        private int floors;

        public House(EstateType type)
            : base(type)
        {
        }

        public int Floors
        {
            get
            {
                return this.floors;
            }
            set
            {
                if(value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("House floors should be in range [0 ... 10]");
                }

                this.floors = value;
            }
        }
    }
}
