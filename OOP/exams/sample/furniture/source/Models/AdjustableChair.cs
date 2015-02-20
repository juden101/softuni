namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            Validation.MinValue("Height", height, 0);

            this.Height = height;
        }
    }
}
