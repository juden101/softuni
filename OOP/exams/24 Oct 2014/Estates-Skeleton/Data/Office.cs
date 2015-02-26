namespace Estates.Data
{
    using System;

    using Interfaces;

    public class Office : BuildingEstate, IOffice
    {
        public Office(EstateType type)
            : base(type)
        {
        }
    }
}
