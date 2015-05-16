﻿namespace TicketOffice.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TicketRepositoryGetTicketsCountUnitTests
    {
        [TestMethod]
        public void TestGetTicketsCountEmptyReturns0()
        {
            ITicketRepository repository = new TicketRepository();
            Assert.AreEqual(0, repository.GetTicketsCount(TicketType.Flight));
            Assert.AreEqual(0, repository.GetTicketsCount(TicketType.Bus));
            Assert.AreEqual(0, repository.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestGetAirTicketsCountReturnsCorrectValues()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddAirTicket(flightNumber: "FX215", from: "Sofia", to: "Varna", airline: "Bulgaria Air", dateTime: new DateTime(2015, 1, 30, 12, 55, 00), price: 130.50M);
            repository.AddAirTicket(flightNumber: "FX407", from: "Varna", to: "Sofia", airline: "Bulgaria Air", dateTime: new DateTime(2015, 2, 2, 7, 45, 00), price: 135.00M);
            Assert.AreEqual(2, repository.GetTicketsCount(TicketType.Flight));
        }

        [TestMethod]
        public void TestGetBusTicketsCountReturnsCorrectValues()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 50, 00), price: 25.00M, travelCompany: "Biomet");
            repository.AddBusTicket(from: "Sofia", to: "Pleven", dateTime: new DateTime(2015, 1, 29, 8, 00, 00), price: 12.00M, travelCompany: "Pleven Trans");
            repository.AddBusTicket(from: "Varna", to: "Rousse", dateTime: new DateTime(2015, 1, 29, 7, 00, 00), price: 17.00M, travelCompany: "Etap");
            Assert.AreEqual(3, repository.GetTicketsCount(TicketType.Bus));
        }

        [TestMethod]
        public void TestGetTrainTicketsCountReturnsCorrectValues()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 26.00M, studentPrice: 16.30M);
            repository.AddTrainTicket(from: "Sofia", to: "Pleven", dateTime: new DateTime(2015, 1, 26, 8, 56, 00), price: 14.00M, studentPrice: 8.30M);
            Assert.AreEqual(2, repository.GetTicketsCount(TicketType.Train));
        }

        [TestMethod]
        public void TestGetTicketsCountForDeletedTicketsReturnsZero()
        {
            ITicketRepository repository = new TicketRepository();
            repository.AddAirTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 211.00M, airline: "New Air", flightNumber: "SV1234");
            repository.AddTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 28, 7, 45, 00), price: 26.00M, studentPrice: 16.30M);
            repository.AddBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), price: 25.00M, travelCompany: "Biomet");
            Assert.AreEqual(1, repository.GetTicketsCount(TicketType.Flight));
            Assert.AreEqual(1, repository.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(1, repository.GetTicketsCount(TicketType.Bus));

            repository.DeleteAirTicket(flightNumber: "SV1234");
            repository.DeleteTrainTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 28, 7, 45, 00));
            repository.DeleteBusTicket(from: "Sofia", to: "Varna", dateTime: new DateTime(2015, 1, 29, 7, 40, 00), travelCompany: "Biomet");
            Assert.AreEqual(0, repository.GetTicketsCount(TicketType.Flight));
            Assert.AreEqual(0, repository.GetTicketsCount(TicketType.Train));
            Assert.AreEqual(0, repository.GetTicketsCount(TicketType.Bus));
        }
    }
}
