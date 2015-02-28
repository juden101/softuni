namespace Estates.Data
{
    using System;

    using Interfaces;

    public class RentOffer : Offer, IRentOffer
    {
        protected decimal pricePerMonth;

        public RentOffer(OfferType type)
            : base(type)
        {
        }
    
        public decimal PricePerMonth
        {
	        get 
	        {
                return this.pricePerMonth;
	        }
	        set 
	        {
                this.pricePerMonth = value;
	        }
        }

        public override string ToString()
        {
            return string.Format("{0}, Price = {1}", base.ToString(), this.PricePerMonth);
        }
    }
}
