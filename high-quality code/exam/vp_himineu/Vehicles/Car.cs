namespace VehicleParkSystem.Vehicles
{
    public class Car : Vehicle
    {
        private const decimal REGULAR_RATE = 2M;
        private const decimal OVERTIME_RATE = 3.5M;

        public Car(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, reservedHours, REGULAR_RATE, OVERTIME_RATE)
        {
        }
    }
}