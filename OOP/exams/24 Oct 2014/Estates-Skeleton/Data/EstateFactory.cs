using Estates.Engine;
using Estates.Interfaces;
using System;

namespace Estates.Data
{
    public class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new EstateEngine();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            return new Estate(type);
        }

        public static IOffer CreateOffer(OfferType type)
        {
            return new Offer(type);
        }
    }
}
