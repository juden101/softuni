namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public abstract class Furniture : IFurniture
    {
        protected string model;
        protected MaterialType material;
        protected decimal price;
        protected decimal height;

        protected Furniture(string model, MaterialType material, decimal price, decimal height)
        {
            this.Model = model;
            this.material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            protected set
            {
                Validation.NullOrEmpty(value);
                Validation.MinStringLength("Model", value, 3);

                this.model = value;
            }
        }

        public string Material
        {
            get
            {
                return this.material.ToString();
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                Validation.MinValue("Price", value, 0);

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                Validation.MinValue("Height", value, 0);

                this.height = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, ",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height);
        }
    }
}