namespace VehicleParkSystem
{
    using System;

    using Vehicles;

    /// <summary>
    /// Defines a vehicle park, holding vehicles(car, motorbike or truck)
    /// and a set of commands to insert, exit, get status and find vehicles from the vehicle park.
    /// </summary>
    public interface IVehiclePark
    {
        /// <summary>
        /// Inserts car to the vehicle park by given car object, sector, placeNumber
        /// and start time date.
        /// </summary>
        /// <param name="car">The car object</param>
        /// <param name="sector">The sector of the vehicle park</param>
        /// <param name="placeNumber">The place number of the vehicle park</param>
        /// <param name="startTime">The start time</param>
        /// <returns>A message "There is no sector (...) in the park" in case of no such sector in the vehicle park
        /// if place doesn't exist, then a message "There is no (...) place in sector (...)".
        /// if place is occupied, then a message "The place (...) is occupied".
        /// if there is a vehicle with the same license,
        /// then a message "There is already a vehicle with license plate (...) in the park".
        /// if everything is alright, then a message "(...) parked successfully at place ((...),(...))".</returns>
        string InsertCar(Car car, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Inserts motorbike to the vehicle park by given motorbike object, sector, placeNumber
        /// and start time date.
        /// </summary>
        /// <param name="motorbike">The motorbike object</param>
        /// <param name="sector">The sector of the vehicle park</param>
        /// <param name="placeNumber">The place number of the vehicle park</param>
        /// <param name="startTime">The start time</param>
        /// <returns>A message "There is no sector (...) in the park" in case of no such sector in the vehicle park
        /// if place doesn't exist, then a message "There is no (...) place in sector (...)".
        /// if place is occupied, then a message "The place (...) is occupied".
        /// if there is a vehicle with the same license,
        /// then a message "There is already a vehicle with license plate (...) in the park".
        /// if everything is alright, then a message "(...) parked successfully at place ((...),(...))".</returns>
        string InsertMotorbike(Motorbike motorbike, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Inserts truck to the vehicle park by given truck object, sector, placeNumber
        /// and start time date.
        /// </summary>
        /// <param name="truck">The truck object</param>
        /// <param name="sector">The sector of the vehicle park</param>
        /// <param name="placeNumber">The place number of the vehicle park</param>
        /// <param name="startTime">The start time</param>
        /// <returns>A message "There is no sector (...) in the park" in case of no such sector in the vehicle park
        /// if place doesn't exist, then a message "There is no (...) place in sector (...)".
        /// if place is occupied, then a message "The place (...) is occupied".
        /// if there is a vehicle with the same license,
        /// then a message "There is already a vehicle with license plate (...) in the park".
        /// if everything is alright, then a message "(...) parked successfully at place ((...),(...))".</returns>
        string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime);

        /// <summary>
        /// Exits vehicle from the vehicle park by given license plate, end time and amount paid
        /// </summary>
        /// <param name="licensePlate">The license plate of the vehicle</param>
        /// <param name="endTime">The end time</param>
        /// <param name="amountPaid">The amount paid to the vehicle park</param>
        /// <returns>A message "There is no vehicle with license plate (...) in the park" in case of no such vehicle in the vehicle park
        /// if everything is alright, then a message
        ///    ********************
        ///    Vehicle(...) [(...)], owned by (...)
        ///    at place ((...),(...))
        ///    Rate: (...)
        ///    Overtime rate: (...)
        ///    --------------------
        ///    Total: (...)
        ///    Paid: (...)
        ///    Change: (...)
        /// </returns>
        string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid);

        /// <summary>
        /// Returns the current status of the vehicle park
        /// </summary>
        /// <returns>A message holding all the vehicles currently parked in the park</returns>
        string GetStatus();

        /// <summary>
        /// Finds a vehicle in the vehicle parking by given license plate
        /// </summary>
        /// <param name="licensePlate">The license plate of the vehicle</param>
        /// <returns>A message "There is no vehicle with license plate (...) in the park" if there is no such vehicle
        /// or a message holding the found vehicle</returns>
        string FindVehicle(string licensePlate);

        /// <summary>
        /// Finds a vehicle in the vehicle parking by given owner name
        /// </summary>
        /// <param name="owner">The name of the owner of the vehicles</param>
        /// <returns>A message "No vehicles by (...)" if there is no person with vehicles in the park
        /// or a message holding the found vehicles</returns>
        string FindVehiclesByOwner(string owner);
    }
}