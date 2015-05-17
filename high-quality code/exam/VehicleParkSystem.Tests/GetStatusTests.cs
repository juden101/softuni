namespace VehicleParkSystem.Tests
{
    using System;
    using System.Threading;
    using System.Globalization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using VehicleParkSystem;

    [TestClass]
    public class GetStatusTests
    {
        private Engine engine;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            this.engine = new Engine();
        }

        [TestMethod]
        public void Test_NonInitializedVehiclePark_ShouldReturnError()
        {
            string command = "Status {}";
            string resultMessage = this.engine.RunCommand(command);
            string expectedResultMessage = "The vehicle park has not been set up";

            Assert.AreEqual(expectedResultMessage, resultMessage);
        }

        [TestMethod]
        public void Test_VehicleParkWithEmptyVehiclePark_ShouldReturnEmptyResult()
        {
            string createParkCommand = "SetupPark {\"sectors\": 3, \"placesPerSector\": 5}";
            this.engine.RunCommand(createParkCommand);

            string command = "Status {}";
            string resultMessage = this.engine.RunCommand(command);
            string expectedResultMessage = @"Sector 1: 0 / 5 (0% full)
Sector 2: 0 / 5 (0% full)
Sector 3: 0 / 5 (0% full)";

            Assert.AreEqual(expectedResultMessage, resultMessage);
        }

        [TestMethod]
        public void Test_VehicleParkWithParkedVehicleInTheVehiclePark_ShouldReturnResultWithOneCar()
        {
            string createParkCommand = "SetupPark {\"sectors\": 3, \"placesPerSector\": 5}";
            this.engine.RunCommand(createParkCommand);

            string addVehicleCommand = "Park {\"type\": \"car\", \"time\": \"2015-05-04T10:30:00.0000000\", \"sector\": 1, \"place\": 5, \"licensePlate\": \"CA1001HH\", \"owner\": \"Jay Margareta\", \"hours\": 1}";
            this.engine.RunCommand(addVehicleCommand);

            string command = "Status {}";
            string resultMessage = this.engine.RunCommand(command);
            string expectedResultMessage = @"Sector 1: 1 / 5 (20% full)
Sector 2: 0 / 5 (0% full)
Sector 3: 0 / 5 (0% full)";

            Assert.AreEqual(expectedResultMessage, resultMessage);
        }

        [TestMethod]
        public void Test_VehicleParkWithExitedParkedVehicleInTheVehiclePark_ShouldReturnResultWithOneCar()
        {
            string createParkCommand = "SetupPark {\"sectors\": 3, \"placesPerSector\": 5}";
            this.engine.RunCommand(createParkCommand);

            string addVehicleCommand = "Park {\"type\": \"car\", \"time\": \"2015-05-04T10:30:00.0000000\", \"sector\": 1, \"place\": 5, \"licensePlate\": \"CA1001HH\", \"owner\": \"Jay Margareta\", \"hours\": 1}";
            this.engine.RunCommand(addVehicleCommand);

            string exitVehicleCommand = "Exit {\"licensePlate\": \"CA1001HH\", \"time\": \"2015-05-04T11:40:00.0000000\", \"paid\": 100.00}";
            this.engine.RunCommand(exitVehicleCommand);

            string command = "Status {}";
            string resultMessage = this.engine.RunCommand(command);
            string expectedResultMessage = @"Sector 1: 0 / 5 (0% full)
Sector 2: 0 / 5 (0% full)
Sector 3: 0 / 5 (0% full)";

            Assert.AreEqual(expectedResultMessage, resultMessage);
        }
    }
}
