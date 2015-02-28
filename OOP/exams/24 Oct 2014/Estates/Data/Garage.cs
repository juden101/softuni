namespace Estates.Data
{
    using System;

    using Interfaces;

    public class Garage : Estate, IGarage
    {
        private int width;
        private int height;

        public Garage(EstateType type)
            : base(type)
        {
        }

        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if(value < 0 || value > 500)
                {
                    throw new ArgumentOutOfRangeException("Garage width should be in range [0 ... 500].");
                }

                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value < 0 || value > 500)
                {
                    throw new ArgumentOutOfRangeException("Garage height should be in range [0 ... 500].");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Width: {1}, Height: {2}", base.ToString(), this.Width, this.Height);
        }
    }
}
