namespace VehicleParkSystem.Vehicles
{
    public class Motorbike : Vehicle
    {
        private const decimal REGULAR_RATE = 1.35M;
        private const decimal OVERTIME_RATE = 3M;

        public Motorbike(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, reservedHours, REGULAR_RATE, OVERTIME_RATE)
        {
        }
    }
}
