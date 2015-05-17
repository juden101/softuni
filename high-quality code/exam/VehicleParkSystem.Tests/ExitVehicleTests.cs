namespace VehicleParkSystem.Tests
{
    using System;
    using System.Threading;
    using System.Globalization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using VehicleParkSystem;

    [TestClass]
    public class ExitVehicleTests
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
        public void Test_ExitNonExistingVehicle_ShouldReturnAnError()
        {
            string command = "Exit {\"licensePlate\": \"CA5555AH\", \"time\": \"2015-05-04T11:40:00.0000000\", \"paid\": 100.00}";
            string resultMessage = this.engine.RunCommand(command);
            string expectedResultMessage = "There is no vehicle with license plate CA5555AH in the park";

            Assert.AreEqual(expectedResultMessage, resultMessage);
        }

        [TestMethod]
        public void Test_ExitExistingVehicle_VehicleShouldExit()
        {
            string command = "Park {\"type\": \"car\", \"time\": \"2015-05-04T10:30:00.0000000\", \"sector\": 1, \"place\": 5, \"licensePlate\": \"CA5555AH\", \"owner\": \"Jay Margareta\", \"hours\": 1}";
            this.engine.RunCommand(command);

            command = "Exit {\"licensePlate\": \"CA5555AH\", \"time\": \"2015-05-04T11:40:00.0000000\", \"paid\": 100.00}";
            string resultMessage = this.engine.RunCommand(command);
            string expectedResultMessage = @"********************
Car [CA5555AH], owned by Jay Margareta
at place (1,5)
Rate: $2.00
Overtime rate: $0.00
--------------------
Total: $2.00
Paid: $100.00
Change: $98.00
********************";

            Assert.AreEqual(expectedResultMessage, resultMessage);
        }
    }
}
