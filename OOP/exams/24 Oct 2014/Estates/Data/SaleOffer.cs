namespace Estates.Data
{
    using System;

    using Interfaces;

    public class SaleOffer : Offer, ISaleOffer
    {
        protected decimal price;

        public SaleOffer(OfferType type)
            : base(type)
        {
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Price = {1}", base.ToString(), this.Price);
        }
    }
}
