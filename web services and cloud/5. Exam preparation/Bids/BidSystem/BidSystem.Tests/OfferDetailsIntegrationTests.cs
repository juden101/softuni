using BidSystem.Data;
using BidSystem.Data.Models;
using BidSystem.RestServices;
using BidSystem.RestServices.Models.ViewModels;
using BidSystem.Tests.Models;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BidSystem.Tests
{
    [TestClass]
    public class OfferDetailsIntegrationTests
    {
        [TestMethod]
        public void GetDetailedOffer_ShouldReturn200OK_ExistingOffer()
        {
            // Arrange
            TestingEngine.CleanDatabase();
            var userSession = TestingEngine.RegisterUser("peter", "pAssW@rd#123456");
            var offersToAdds = new OfferModel[]
            {
                new OfferModel() { Title = "First Offer (Expired)", Description = "Description", InitialPrice = 200, ExpirationDateTime = DateTime.Now.AddDays(-5)},
                new OfferModel() { Title = "Another Offer (Expired)", InitialPrice = 15.50m, ExpirationDateTime = DateTime.Now.AddDays(-1)},
                new OfferModel() { Title = "Second Offer (Active 3 months)", Description = "Description", InitialPrice = 500, ExpirationDateTime = DateTime.Now.AddMonths(3)},
                new OfferModel() { Title = "Third Offer (Active 6 months)", InitialPrice = 120, ExpirationDateTime = DateTime.Now.AddMonths(6)},
            };

            // Act
            foreach (var offer in offersToAdds)
            {
                var httpResult = TestingEngine.CreateOfferHttpPost(userSession.Access_Token, offer.Title, offer.Description, offer.InitialPrice, offer.ExpirationDateTime);
            }

            var firstOfferId = TestingEngine.GetRandomOfferIdFromDb();
            var getOfferDetailsHttpResult = TestingEngine.GetDetailedOfferHttpGet(firstOfferId);
            var offerDetails = getOfferDetailsHttpResult.Content.ReadAsAsync<DetailedOfferViewModel>().Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, getOfferDetailsHttpResult.StatusCode);
            Assert.AreEqual(offersToAdds[0].Title, offerDetails.Title);
            Assert.AreEqual(offersToAdds[0].Description, offerDetails.Description);
            Assert.AreEqual(offersToAdds[0].InitialPrice, offerDetails.InitialPrice);
            Assert.AreEqual(0, offerDetails.Bids.Count());
            Assert.IsTrue(offerDetails.IsExpired);
        }

        [TestMethod]
        public void GetDetailedOffer_ShouldReturn204NotFound_NonExistingOffer()
        {
            TestingEngine.CleanDatabase();
            var getOfferDetailsHttpResult = TestingEngine.GetDetailedOfferHttpGet(-1);
            Assert.AreEqual(HttpStatusCode.NotFound, getOfferDetailsHttpResult.StatusCode);
        }
    }
}