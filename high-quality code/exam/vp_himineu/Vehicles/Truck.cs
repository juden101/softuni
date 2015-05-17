namespace VehicleParkSystem.Vehicles
{
    public class Truck : Vehicle
    {
        private const decimal REGULAR_RATE = 4.75M;
        private const decimal OVERTIME_RATE = 6.2M;

        public Truck(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, reservedHours, REGULAR_RATE, OVERTIME_RATE)
        {
        }
    }
}