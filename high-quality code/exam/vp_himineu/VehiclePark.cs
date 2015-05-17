namespace VehicleParkSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using Vehicles;

    public class VehiclePark : IVehiclePark
    {
        public VehiclePark(int numberOfSectors, int placesPerSector)
        {
            this.Layout = new Layout(numberOfSectors, placesPerSector);
            this.DataContainer = new DataContainer(numberOfSectors);
        }

        private Layout Layout
        {
            get;
            set;
        }

        private DataContainer DataContainer
        {
            get;
            set;
        }

        public string InsertCar(Car car, int sector, int place, DateTime duration)
        {
            string vehicleInsertionResult = this.InsertVehicle(car, sector, place, duration);

            return vehicleInsertionResult;
        }

        public string InsertMotorbike(Motorbike motorbike, int sector, int place, DateTime duration)
        {
            string vehicleInsertionResult = this.InsertVehicle(motorbike, sector, place, duration);

            return vehicleInsertionResult;
        }

        public string InsertTruck(Truck truck, int sector, int place, DateTime duration)
        {
            string vehicleInsertionResult = this.InsertVehicle(truck, sector, place, duration);

            return vehicleInsertionResult;
        }

        public string InsertVehicle(IVehicle vehicle, int sector, int place, DateTime duration)
        {
            if (sector > this.Layout.Sectors)
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > this.Layout.PlacesPerSector)
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (this.DataContainer.ParkingLots.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (this.DataContainer.LicensePlates.ContainsKey(vehicle.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", vehicle.LicensePlate);
            }

            this.DataContainer.ParkedVehicles[vehicle] = string.Format("({0},{1})", sector, place);
            this.DataContainer.ParkingLots[string.Format("({0},{1})", sector, place)] = vehicle;
            this.DataContainer.LicensePlates[vehicle.LicensePlate] = vehicle;
            this.DataContainer.Durations[vehicle] = duration;
            this.DataContainer.Count[sector - 1]++;

            return string.Format("{0} parked successfully at place ({1},{2})", vehicle.GetType().Name, sector, place);
        }
        
        public string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid)
        {
            var vehicle = (this.DataContainer.LicensePlates.ContainsKey(licensePlate)) ? this.DataContainer.LicensePlates[licensePlate] : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
            }

            var start = this.DataContainer.Durations[vehicle];
            int endd = (int)Math.Round((endTime - start).TotalHours);
            var ticket = new StringBuilder();
            ticket.AppendLine(
                new string('*', 20))
                .AppendFormat("{0}", vehicle.ToString())
                .AppendLine()
                .AppendFormat("at place {0}", this.DataContainer.ParkedVehicles[vehicle])
                .AppendLine()
                .AppendFormat("Rate: ${0:F2}", (vehicle.ReservedHours * vehicle.RegularRate))
                .AppendLine()
                .AppendFormat("Overtime rate: ${0:F2}", 
                    (endd > vehicle.ReservedHours ? (endd - vehicle.ReservedHours) * vehicle.OvertimeRate : 0))
                .AppendLine()
                .AppendLine(new string('-', 20))
                .AppendFormat("Total: ${0:F2}", 
                    (vehicle.ReservedHours * vehicle.RegularRate + (endd > vehicle.ReservedHours ? (endd - vehicle.ReservedHours) * vehicle.OvertimeRate : 0)))
                .AppendLine()
                .AppendFormat("Paid: ${0:F2}", amountPaid)
                .AppendLine()
                .AppendFormat("Change: ${0:F2}", amountPaid - ((vehicle.ReservedHours * vehicle.RegularRate) + (endd > vehicle.ReservedHours ? (endd - vehicle.ReservedHours) * vehicle.OvertimeRate : 0)))
                .AppendLine()
                .Append(new string('*', 20));
            
            int sector = int.Parse(this.DataContainer.ParkedVehicles[vehicle].Split(new[] { "(", ",", ")" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            this.DataContainer.ParkingLots.Remove(this.DataContainer.ParkedVehicles[vehicle]);
            this.DataContainer.ParkedVehicles.Remove(vehicle);
            this.DataContainer.LicensePlates.Remove(vehicle.LicensePlate);
            this.DataContainer.Durations.Remove(vehicle);
            this.DataContainer.Count[sector - 1]--;

            return ticket.ToString();
        }

        public string GetStatus()
        {
            // Bug fix: incorrect index in placeholders fixed

            var places = this.DataContainer.Count.Select((usedPlaces, index) => string.Format(
                "Sector {0}: {1} / {2} ({3}% full)",
                index + 1,
                usedPlaces,
                this.Layout.PlacesPerSector,
                Math.Round((double)usedPlaces / this.Layout.PlacesPerSector * 100)));

            return string.Join(Environment.NewLine, places);
        }

        public string FindVehicle(string licensePlate)
        {
            IVehicle vehicle = null;

            if (this.DataContainer.LicensePlates.ContainsKey(licensePlate))
            {
                vehicle = this.DataContainer.LicensePlates[licensePlate];
                return PrintVehicles(new[] { vehicle });
            }

            return string.Format("There is no vehicle with license plate {0} in the park", licensePlate);
        }

        public string FindVehiclesByOwner(string owner)
        {
            if (this.DataContainer.ParkingLots.Values.Where(v => v.Owner == owner).Any())
            {
                // PERFORMANCE: there was unnecessary foreach loop creating the same list
                var vehiclesFound = this.DataContainer.ParkingLots.Values.ToList();
                var vehiclesResult = vehiclesFound.Where(v => v.Owner == owner).ToList();

                return string.Join(Environment.NewLine, PrintVehicles(vehiclesResult));
            }

            return string.Format("No vehicles by {0}", owner);
        }

        private string PrintVehicles(IEnumerable<IVehicle> vehicles)
        {
            return string.Join(Environment.NewLine, vehicles.Select(
                vehicle => string.Format(
                    "{0}{1}Parked at {2}", vehicle.ToString(), Environment.NewLine, this.DataContainer.ParkedVehicles[vehicle]))
                );
        }
    }
}