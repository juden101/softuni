namespace Estates.Data
{
    using System;

    using Interfaces;

    public class Offer : IOffer
    {
        private OfferType type;
        private IEstate estate;

        public Offer(OfferType type)
        {
            this.Type = type;
        }

        public OfferType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public IEstate Estate
        {
            get
            {
                return this.estate;
            }
            set
            {
                this.estate = value;
            }
        }
    }
}
