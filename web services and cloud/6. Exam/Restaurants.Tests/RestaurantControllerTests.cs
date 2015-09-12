using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

using Restaurants.Data;
using Restaurants.Services.Controllers;
using Restaurants.Services.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using Restaurants.Services.Models.BindingModels;
using Restaurants.Data.UnitOfWork;
using Restaurants.Services.Models.ViewModels;
using System.Collections.Generic;

namespace Restaurants.Tests
{
    [TestClass]
    public class RestaurantsControllerTests
    {
        private MockContainer mock;

        [TestInitialize]
        public void InitTest()
        {
            this.mock = new MockContainer();
            this.mock.PrepareMock();
        }

        [TestMethod]
        public void GetAllRestaurantsByTown_ShouldReturn200OK_WithRestaurants()
        {
            // Arrange
            var fakeRestaurants = this.mock.RestaurantRepositoryMock.Object.All();

            var mockContext = new Mock<IRestaurantsData>();
            mockContext.Setup(c => c.Restaurants)
                .Returns(this.mock.RestaurantRepositoryMock.Object);

            var restaurantsController = new RestaurantsController(mockContext.Object);
            this.SetupController(restaurantsController);

            // Act
            var response = restaurantsController.GetRestaurants(1)
                .ExecuteAsync(CancellationToken.None).Result;

            var output = response.Content.ReadAsAsync<List<RestarauntViewModel>>().Result;
            
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            foreach (RestarauntViewModel restaurant in output)
            {
                Assert.AreNotEqual(restaurant.Id, -1);
                Assert.IsNotNull(restaurant.Name);
                Assert.IsNotNull(restaurant.Town);
                Assert.IsNotNull(restaurant.Rating);
            }
        }

        [TestMethod]
        public void GetNonExistingTownRestaurants_ShouldReturn200Ok_EmptyResults()
        {
            // Arrange
            var fakeRestaurants = this.mock.RestaurantRepositoryMock.Object.All();

            var mockContext = new Mock<IRestaurantsData>();
            mockContext.Setup(c => c.Restaurants)
                .Returns(this.mock.RestaurantRepositoryMock.Object);

            var restaurantsController = new RestaurantsController(mockContext.Object);
            this.SetupController(restaurantsController);

            // Act
            var response = restaurantsController.GetRestaurants(-1)
                .ExecuteAsync(CancellationToken.None).Result;

            var output = response.Content.ReadAsAsync<List<RestarauntViewModel>>().Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(output.Any(), false);
        }

        /*
        [TestMethod]
        public void RateExistingRestaurantWithCorrectData_ShouldReturn200OK_RateRestaurantInReposiory()
        {
            // Arrange
            var fakeRestaurantToRate = this.mock.RestaurantRepositoryMock.Object.All().FirstOrDefault();
            var rateRestaurant = new RateRestaurantBindingModel
            {
                Stars = 5
            };

            var mockContext = new Mock<IRestaurantsData>();
            mockContext.Setup(c => c.Restaurants)
                .Returns(this.mock.RestaurantRepositoryMock.Object);

            var restaurantsController = new RestaurantsController(mockContext.Object);
            this.SetupController(restaurantsController);

            // Act
            var response = restaurantsController.RateRestaurant(fakeRestaurantToRate.Id, rateRestaurant)
                .ExecuteAsync(CancellationToken.None).Result;

            // Assert
            var fakeRestaurantAfterRate = this.mock.RestaurantRepositoryMock.Object.All().LastOrDefault();
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            //Assert.AreEqual(rateRestaurant.Title, fakeRestaurantAfterRate.Ratings);
            //Assert.AreEqual(newBugData.Description, fakeBugAfterEditing.Description);
            //Assert.AreEqual(newBugData.Status, fakeBugAfterEditing.Status.ToString());
        }*/

        private void SetupController(RestaurantsController controller)
        {
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
        }
    }
}