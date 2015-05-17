namespace VehicleParkSystem
{
    using System;

    using Vehicles;
    
    public class Executor
    {
        private VehiclePark VehiclePark
        {
            get;
            set;
        }

        public string Execute(ICommand command)
        {
            if (command.Name != "SetupPark" && this.VehiclePark == null)
            {
                return "The vehicle park has not been set up";
            }

            string commandExecutionOutput = string.Empty;

            switch (command.Name)
            {
                case "SetupPark":
                    // Bug fix: Vehicle park used to create more secotors than wanted
                    int sectors = int.Parse(command.Parameters["sectors"]);
                    int placesPerSector = int.Parse(command.Parameters["placesPerSector"]);

                    this.VehiclePark = new VehiclePark(sectors, placesPerSector);

                    commandExecutionOutput = "Vehicle park created";
                    break;
                case "Park":
                    string licensePlate = command.Parameters["licensePlate"];
                    string owner = command.Parameters["owner"];
                    int reservedHours = int.Parse(command.Parameters["hours"]);

                    int sector = int.Parse(command.Parameters["sector"]);
                    int place = int.Parse(command.Parameters["place"]);
                    DateTime time = DateTime.Parse(command.Parameters["time"], null, System.Globalization.DateTimeStyles.RoundtripKind);

                    switch (command.Parameters["type"])
                    {
                        case "car":
                            string carInsertionOutput = this.VehiclePark.InsertCar(
                                new Car(licensePlate, owner, reservedHours),
                                sector,
                                place,
                                time);

                            commandExecutionOutput = carInsertionOutput;
                            break;
                        case "motorbike":
                            string motorbikeInsertionOutput = this.VehiclePark.InsertMotorbike(
                                new Motorbike(licensePlate, owner, reservedHours),
                                    sector,
                                    place,
                                    time);
                                
                            commandExecutionOutput = motorbikeInsertionOutput;
                            break;
                        case "truck":
                            string truckInsertionOutput = this.VehiclePark.InsertTruck(
                                new Truck(licensePlate, owner, reservedHours),
                                    sector,
                                    place,
                                    time);

                            commandExecutionOutput = truckInsertionOutput;
                            break;
                    }

                    break;
                case "Exit":
                    string exitVehicleOutput = this.VehiclePark.ExitVehicle(
                        command.Parameters["licensePlate"],
                        DateTime.Parse(command.Parameters["time"], null, System.Globalization.DateTimeStyles.RoundtripKind),
                        decimal.Parse(command.Parameters["paid"]));

                    commandExecutionOutput = exitVehicleOutput;
                    break;
                case "Status":
                    string vehicleParkStatus = this.VehiclePark.GetStatus();

                    commandExecutionOutput = vehicleParkStatus;
                    break;
                case "FindVehicle":
                    string findVehicleByLicensePlateOutput = this.VehiclePark.FindVehicle(command.Parameters["licensePlate"]);

                    commandExecutionOutput = findVehicleByLicensePlateOutput;
                    break;
                case "VehiclesByOwner":
                    string findVehiclesByOwner = this.VehiclePark.FindVehiclesByOwner(command.Parameters["owner"]);

                    commandExecutionOutput = findVehiclesByOwner;
                    break;
                default:
                    throw new IndexOutOfRangeException("Invalid command.");
            }

            return commandExecutionOutput;
        }
    }
}