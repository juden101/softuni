namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    class Chair : Furniture, IChair
    {
        protected int numberOfLegs;

        public Chair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }
            protected set
            {
                Validation.MinValue("Legs", value, 0);

                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Legs: {0}", this.NumberOfLegs);
        }
    }
}
