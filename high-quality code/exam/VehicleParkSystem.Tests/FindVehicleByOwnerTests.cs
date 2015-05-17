namespace VehicleParkSystem.Tests
{
    using System;
    using System.Threading;
    using System.Globalization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using VehicleParkSystem;

    [TestClass]
    public class FindVehicleByOwnerTests
    {
        private Engine engine;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            this.engine = new Engine();

            string createParkCommand = "SetupPark {\"sectors\": 3, \"placesPerSector\": 5}";
            this.engine.RunCommand(createParkCommand);
        }

        [TestMethod]
        public void Test_NonExistingOwner_ShouldReturnError()
        {
            string command = "VehiclesByOwner {\"owner\": \"Jay Margareta\"}";
            string resultMessage = this.engine.RunCommand(command);
            string expectedResultMessage = "No vehicles by Jay Margareta";

            Assert.AreEqual(expectedResultMessage, resultMessage);
        }

        [TestMethod]
        public void Test_ExistingOwnerInTheVehiclePark_ShouldReturnCar()
        {
            string insertVehicleCommand = "Park {\"type\": \"car\", \"time\": \"2015-05-04T10:30:00.0000000\", \"sector\": 1, \"place\": 5, \"licensePlate\": \"CA1001HH\", \"owner\": \"Jay Margareta\", \"hours\": 1}";
            this.engine.RunCommand(insertVehicleCommand);

            string command = "VehiclesByOwner {\"owner\": \"Jay Margareta\"}";
            string resultMessage = this.engine.RunCommand(command);
            string expectedResultMessage = @"Car [CA1001HH], owned by Jay Margareta
Parked at (1,5)";

            Assert.AreEqual(expectedResultMessage, resultMessage);
        }
    }
}
