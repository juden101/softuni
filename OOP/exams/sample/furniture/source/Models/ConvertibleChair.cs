namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted = false;
        private decimal convertedHeight = 0.10m;
        private decimal initialHeight;

        public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.initialHeight = height;
        }

        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }
        }

        public void Convert()
        {
            if(this.IsConverted) {
                this.isConverted = false;
                this.Height = this.initialHeight;
            }
            else
            {
                this.isConverted = true;
                this.Height = this.convertedHeight;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}
