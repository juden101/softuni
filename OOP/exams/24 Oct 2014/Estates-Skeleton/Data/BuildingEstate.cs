namespace Estates.Data
{
    using System;

    using Interfaces;

    public class BuildingEstate : Estate, IBuildingEstate
    {
        private int rooms;
        private bool hasElevator;

        public BuildingEstate(EstateType type)
            : base(type)
        {
        }

        public int Rooms
        {
            get
            {
                return this.rooms;
            }
            set
            {
                this.rooms = value;
            }
        }

        public bool HasElevator
        {
            get
            {
                return this.hasElevator;
            }
            set
            {
                this.hasElevator = value;
            }
        }
    }
}
