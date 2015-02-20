namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    class Table : Furniture, ITable
    {
        protected decimal length;
        protected decimal width;

        public Table(string model, MaterialType materialType, decimal price, decimal height, decimal length, decimal width)
            : base(model, materialType, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }
            set
            {
                Validation.MinValue("Length", value, 0);

                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
            set
            {
                Validation.MinValue("Width", value, 0);

                this.width = value;
            }
        }

        public decimal Area
        {
            get
            {
                return this.Length * this.Width;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area);
        }
    }
}
