namespace VehicleParkSystem
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class DataContainer
    {
        public DataContainer(int numberOfSectors)
        {
            this.ParkedVehicles = new Dictionary<IVehicle, string>();
            this.ParkingLots = new Dictionary<string, IVehicle>();
            this.LicensePlates = new Dictionary<string, IVehicle>();
            this.Durations = new Dictionary<IVehicle, DateTime>();
            this.Count = new int[numberOfSectors];
        }

        public Dictionary<IVehicle, string> ParkedVehicles
        {
            get;
            set;
        }

        public Dictionary<string, IVehicle> ParkingLots
        {
            get;
            set;
        }

        public Dictionary<string, IVehicle> LicensePlates
        {
            get;
            set;
        }

        public Dictionary<IVehicle, DateTime> Durations
        {
            get;
            set;
        }

        public int[] Count
        {
            get;
            set;
        }
    }
}