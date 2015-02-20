namespace FurnitureManufacturer.Models
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using FurnitureManufacturer.Interfaces;

    class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private IList<IFurniture> furnitures = new List<IFurniture>();

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validation.NullOrEmpty(value);
                Validation.MinStringLength("Company name", value, 3);

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                Validation.RegistrationNumber(value);

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.Furnitures.Where(f => f.Model.ToLowerInvariant() == model.ToLowerInvariant()).FirstOrDefault();
        }

        public string Catalog()
        {
            StringBuilder catalog = new StringBuilder();

            string catalogHeader = string.Format("{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture");
            catalog.Append(catalogHeader);

            foreach (IFurniture furniture in this.Furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model))
            {
                catalog.AppendLine();
                catalog.Append(furniture.ToString());
            }

            return catalog.ToString();
        }
    }
}
