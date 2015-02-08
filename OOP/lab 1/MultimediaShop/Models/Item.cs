namespace MultimediaShop.Models
{
    using System;
    using System.Collections.Generic;
    using MultimediaShop.Interfaces;

    class Item : IItem
    {
        private string id;
        private string title;
        private double price;
        private IList<string> genres;

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if(Validation.ValidateId(value)) {
                    this.id = value;
                }
                else
                {
                    throw new ArgumentException("The id must be a non-empty string, at least 4 symbols long.");
                }
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                if (Validation.ValidateString(value))
                {
                    this.title = value;
                }
                else
                {
                    throw new ArgumentNullException("Title cannot be null or empty.");
                }
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (Validation.ValidateNumber(value))
                {
                    this.price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The price should be greater than 0.");
                }
            }
        }

        public IList<string> Genres { get; set; }
    }
}
