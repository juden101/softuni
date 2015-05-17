namespace VehicleParkSystem.Tests
{
    using System;
    using System.Threading;
    using System.Globalization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using VehicleParkSystem;

    [TestClass]
    public class InsertCarTests
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
        public void Test_AddCar_ShouldAddTheCar()
        {
            string command = "Park {\"type\": \"car\", \"time\": \"2015-05-04T10:30:00.0000000\", \"sector\": 1, \"place\": 5, \"licensePlate\": \"CA1001HH\", \"owner\": \"Jay Margareta\", \"hours\": 1}";
            string resultMessage = this.engine.RunCommand(command);
            string expectedResultMessage = "Car parked successfully at place (1,5)";

            Assert.AreEqual(expectedResultMessage, resultMessage);
        }

        [TestMethod]
        public void Test_AddCarWithNonExistantSector_ShouldReturnErrorMessage()
        {
            string command = "Park {\"type\": \"car\", \"time\": \"2015-05-04T10:30:00.0000000\", \"sector\": 18, \"place\": 5, \"licensePlate\": \"CA1001HH\", \"owner\": \"Jay Margareta\", \"hours\": 1}";
            string resultMessage = this.engine.RunCommand(command);
            string expectedResultMessage = "There is no sector 18 in the park";

            Assert.AreEqual(expectedResultMessage, resultMessage);
        }

        [TestMethod]
        public void Test_AddCarWithNonExistantPlace_ShouldReturnErrorMessage()
        {
            string command = "Park {\"type\": \"car\", \"time\": \"2015-05-04T10:30:00.0000000\", \"sector\": 3, \"place\": 15, \"licensePlate\": \"CA1001HH\", \"owner\": \"Jay Margareta\", \"hours\": 1}";
            string resultMessage = this.engine.RunCommand(command);
            string expectedResultMessage = "There is no place 15 in sector 3";

            Assert.AreEqual(expectedResultMessage, resultMessage);
        }

        [TestMethod]
        public void Test_AddCarWithTakenPlace_ShouldReturnErrorMessage()
        {
            string command = "Park {\"type\": \"car\", \"time\": \"2015-05-04T10:30:00.0000000\", \"sector\": 3, \"place\": 3, \"licensePlate\": \"CA1001HH\", \"owner\": \"Jay Margareta\", \"hours\": 1}";
            this.engine.RunCommand(command);
            
            command = "Park {\"type\": \"car\", \"time\": \"2015-05-04T10:30:00.0000000\", \"sector\": 3, \"place\": 3, \"licensePlate\": \"CA1001HH\", \"owner\": \"Jay Margareta\", \"hours\": 1}";
            string resultMessage = this.engine.RunCommand(command);
            string expectedResultMessage = "The place (3,3) is occupied";

            Assert.AreEqual(expectedResultMessage, resultMessage);
        }

        [TestMethod]
        public void Test_AddCarWithTheSameLicense_ShouldReturnErrorMessage()
        {
            string command = "Park {\"type\": \"car\", \"time\": \"2015-05-04T10:30:00.0000000\", \"sector\": 3, \"place\": 3, \"licensePlate\": \"CA1001HH\", \"owner\": \"Jay Margareta\", \"hours\": 1}";
            this.engine.RunCommand(command);

            command = "Park {\"type\": \"car\", \"time\": \"2015-05-04T10:30:00.0000000\", \"sector\": 2, \"place\": 3, \"licensePlate\": \"CA1001HH\", \"owner\": \"Jay Margareta\", \"hours\": 1}";
            string resultMessage = this.engine.RunCommand(command);
            string expectedResultMessage = "There is already a vehicle with license plate CA1001HH in the park";

            Assert.AreEqual(expectedResultMessage, resultMessage);
        }
    }
}
