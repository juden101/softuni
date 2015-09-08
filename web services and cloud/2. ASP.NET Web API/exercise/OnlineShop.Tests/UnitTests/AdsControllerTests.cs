using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Services.Controllers;
using OnlineShop.Data.UnitOfWork;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using BookShop.Services.Models;
using System.Web.Http.Routing;
using OnlineShop.Services.Infrastructure;
using OnlineShop.Services.Models;

namespace OnlineShop.Tests.UnitTests
{
    [TestClass]
    public class AdsControllerTests
    {
        private MockContainer mocks;

        [TestInitialize]
        public void InitTest()
        {
            this.mocks = new MockContainer();
            this.mocks.PrepareMocks();
        }

        [TestMethod]
        public void TestGetAdsShouldReturnAllAdsSortedByType()
        {
            // Arrange
            var fakeAds = this.mocks.AdRepositoryMock.Object.All();

            var mockContext = new Mock<IOnlineShopData>();
            var mockUserIdProvider = new Mock<IUserIdProvider>();
            mockContext
                .Setup(c => c.Ads)
                .Returns(this.mocks.AdRepositoryMock.Object);

            var adsController = new AdsController(mockContext.Object, mockUserIdProvider.Object);
            this.SetupController(adsController);

            // Act
            var response = adsController
                .GetAds()
                .ExecuteAsync(CancellationToken.None).Result;
            
            var adsResponse = response.Content
                .ReadAsAsync<IEnumerable<AdViewModel>>()
                .Result
                .Select(a => a.Id)
                .ToList();

            var orderedFakeAds = this.mocks.AdRepositoryMock.Object.All()
                .Select(AdViewModel.Create)
                .OrderByDescending(a => a.Type)
                .ThenByDescending(a => a.PostedOn)
                .Select(a => a.Id)
                .ToList();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            CollectionAssert.AreEqual(orderedFakeAds, adsResponse);
        }
        
        [TestMethod]
        public void CreateAd_ShouldSuccessfullyAddToRepository()
        {
            // Arrange
            var ads = new List<Ad>();
            var adTypes = new List<AdType>();
            var categories = new List<Category>();

            var fakeUser = this.mocks.UserRepositoryMock.Object.All().FirstOrDefault();

            if (fakeUser == null)
            {
                Assert.Fail("Cannot perform test - no users available.");
            }

            this.mocks.AdRepositoryMock
                .Setup(r => r.Add(It.IsAny<Ad>()))
                .Callback((Ad ad) =>
                {
                    ad.Owner = fakeUser;
                    ads.Add(ad);
                });

            this.mocks.AdTypeRepositoryMock
                .Setup(r => r.Add(It.IsAny<AdType>()))
                .Callback((AdType adType) =>
                {
                    adTypes.Add(adType);
                });

            this.mocks.CategoryRepositoryMock
                .Setup(r => r.Add(It.IsAny<Category>()))
                .Callback((Category category) =>
                {
                    categories.Add(category);
                });

            var mockContext = new Mock<IOnlineShopData>();

            mockContext
                .Setup(c => c.Ads)
                .Returns(this.mocks.AdRepositoryMock.Object);

            mockContext
                .Setup(c => c.AdTypes)
                .Returns(this.mocks.AdTypeRepositoryMock.Object);

            mockContext
                .Setup(c => c.Categories)
                .Returns(this.mocks.CategoryRepositoryMock.Object);

            mockContext
                .Setup(c => c.Users)
                .Returns(this.mocks.UserRepositoryMock.Object);

            var mockUserIdProvider = new Mock<IUserIdProvider>();
            mockUserIdProvider.Setup(uip => uip.GetUserId())
                .Returns(fakeUser.Id);

            var adsController = new AdsController(mockContext.Object, mockUserIdProvider.Object);
            this.SetupController(adsController);

            string randomName = Guid.NewGuid().ToString();
            var newAd = new CreateAdBindingModel()
            {
                Name = randomName,
                Price = 555,
                TypeId = 1,
                Description = "Nothing much to say",
                Categories = new[] { 1, 2, 3 }
            };
            
            // Act
            var response = adsController
                .CreateAd(newAd)
                .ExecuteAsync(CancellationToken.None).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
            Assert.AreEqual(ads.Count, 1);
            Assert.AreEqual(ads[0].Name, newAd.Name);
        }

        [TestMethod]
        public void CloseAdAsOwner_ShouldSuccessfullyRemoveFromRepository()
        {
            // Arrange
            var fakeAds = this.mocks.AdRepositoryMock.Object.All();
            var openAd = fakeAds.FirstOrDefault(ad => ad.Status == AdStatus.Open);

            if (openAd == null)
            {
                Assert.Fail("Cannot perform test - no open ads available.");
            }

            var mockContext = new Mock<IOnlineShopData>();

            mockContext
                .Setup(c => c.Ads)
                .Returns(this.mocks.AdRepositoryMock.Object);

            var mockUserIdProvider = new Mock<IUserIdProvider>();
            mockUserIdProvider.Setup(uip => uip.GetUserId())
                .Returns(openAd.OwnerId);

            var adsController = new AdsController(mockContext.Object, mockUserIdProvider.Object);
            this.SetupController(adsController);

            // Act
            var response = adsController
                .CloseAd(openAd.Id)
                .ExecuteAsync(CancellationToken.None).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            mockContext.Verify(c => c.SaveChanges(), Times.Once);
            Assert.AreNotEqual(openAd.ClosedOn, null);
            Assert.AreEqual(openAd.Status, AdStatus.Closed);
        }

        [TestMethod]
        public void CloseAdAsNonOwner_ShouldReturn400BadRequest()
        {
            var fakeAds = this.mocks.AdRepositoryMock.Object.All();
            var openAd = fakeAds.FirstOrDefault(ad => ad.Status == AdStatus.Open);
            if (openAd == null)
            {
                Assert.Fail("Cannot perform test - no open ads available.");
            }

            var fakeUsers = this.mocks.UserRepositoryMock.Object.All();
            ApplicationUser foreignUser = fakeUsers
                .FirstOrDefault(u => u.Id != openAd.OwnerId);

            if (foreignUser == null)
            {
                Assert.Fail("Cannot perform test - no user who is non owner of the ad.");
            }

            var mockContext = new Mock<IOnlineShopData>();
            mockContext.Setup(c => c.Ads)
                .Returns(this.mocks.AdRepositoryMock.Object);

            var mockUserIdProvider = new Mock<IUserIdProvider>();
            mockUserIdProvider.Setup(uip => uip.GetUserId())
                .Returns(foreignUser.Id);

            var adsController = new AdsController(mockContext.Object, mockUserIdProvider.Object);
            this.SetupController(adsController);

            var response = adsController.CloseAd(openAd.Id)
                .ExecuteAsync(CancellationToken.None).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            mockContext.Verify(c => c.SaveChanges(), Times.Never);
            Assert.IsNull(openAd.ClosedOn);
            Assert.AreEqual(AdStatus.Open, openAd.Status);
        }

        private void SetupController(ApiController controller)
        {
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
        }
    }
}