namespace Estates.Data
{
    using System;

    using Interfaces;

    public class Apartment : BuildingEstate, IApartment
    {
        public Apartment(EstateType type)
            : base(type)
        {
        }
    }
}
