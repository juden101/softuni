using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web;
using Owin;
using Restaurants.Services;
using Restaurants.Data;
using Restaurants.Models;
using BugTracker.Tests.Models;
using System.Net.Http.Headers;
using Restaurants.Services.Models.ViewModels;

namespace Restaurants.Tests
{
    [TestClass]
    public class MealsIntegrationTests
    {
        private static TestServer server;
        private static HttpClient client;

        [AssemblyInitialize]
        public static void InitializeTests(TestContext context)
        {
            server = TestServer.Create(appBuilder =>
            {
                var httpConfig = new HttpConfiguration();
                WebApiConfig.Register(httpConfig);

                var webAppStartup = new Startup();
                webAppStartup.Configuration(appBuilder);

                appBuilder.UseWebApi(httpConfig);
            });

            client = server.HttpClient;
            Seed();
        }

        [AssemblyCleanup]
        public static void AssembyCleanup()
        {
            if (server != null)
            {
                server.Dispose();
            }
        }

        [TestMethod]
        public void EditMeal_ShouldReturn200OK_EditMeal()
        {
            var context = new RestaurantsContext();
            var meal = context.Meals.FirstOrDefault(m => m.Name == "Test meal");

            if (meal == null)
            {
                Assert.Fail("Cannot perform test - no such meal in DB");
            }

            var oldMealName = meal.Name;
            var oldMealPrice = meal.Price;
            var oldMealTypeId = meal.TypeId;

            var endpoint = string.Format("api/meals/{0}", meal.Id);

            var mealEditedContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "Test meal"),
                new KeyValuePair<string, string>("price", "15"),
                new KeyValuePair<string, string>("typeId", "3")
            });

            var loginUserData = LoginUser("test", "testtest");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginUserData.Access_Token);
            var httpResponse = client.PutAsync(endpoint, mealEditedContent).Result;

            var output = httpResponse.Content.ReadAsAsync<List<MealViewModel>>().Result.FirstOrDefault();

            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            Assert.AreEqual(oldMealName, output.Name);
            Assert.AreNotEqual(oldMealPrice, output.Price);
            Assert.AreNotEqual(oldMealTypeId, output.Type);
        }

        [TestMethod]
        public void EditNonExistingMeal_ShouldReturn404NotFound()
        {
            var context = new RestaurantsContext();

            var endpoint = string.Format("api/meals/{0}", -1);

            var mealEditedContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "test edited"),
                new KeyValuePair<string, string>("price", "15"),
                new KeyValuePair<string, string>("typeId", "3")
            });

            var loginUserData = LoginUser("test", "testtest");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginUserData.Access_Token);
            var httpResponse = client.PutAsync(endpoint, mealEditedContent).Result;
            
            Assert.AreEqual(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }

        [TestMethod]
        public void EditMealWithoutData_ShouldReturn400BadRequest()
        {
            var context = new RestaurantsContext();
            var meal = context.Meals.FirstOrDefault(m => m.Name == "Test meal");

            if (meal == null)
            {
                Assert.Fail("Cannot perform test - no such meal in DB");
            }

            var endpoint = string.Format("api/meals/{0}", meal.Id);

            var loginUserData = LoginUser("test", "testtest");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginUserData.Access_Token);
            var httpResponse = client.PutAsync(endpoint, null).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void EditMealWithoutWrongData_ShouldReturn400BadRequest()
        {
            var context = new RestaurantsContext();
            var meal = context.Meals.FirstOrDefault(m => m.Name == "Test meal");

            if (meal == null)
            {
                Assert.Fail("Cannot perform test - no such meal in DB");
            }

            var endpoint = string.Format("api/meals/{0}", meal.Id);

            var mealEditedContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", ""),
                new KeyValuePair<string, string>("price", ""),
                new KeyValuePair<string, string>("typeId", "")
            });

            var loginUserData = LoginUser("test", "testtest");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginUserData.Access_Token);
            var httpResponse = client.PutAsync(endpoint, mealEditedContent).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }

        [TestMethod]
        public void EditMealWithWrongMealType_ShouldReturn400BadRequest()
        {
            var context = new RestaurantsContext();
            var meal = context.Meals.FirstOrDefault(m => m.Name == "Test meal");

            if (meal == null)
            {
                Assert.Fail("Cannot perform test - no such meal in DB");
            }

            var endpoint = string.Format("api/meals/{0}", meal.Id);

            var mealEditedContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "asdasdas"),
                new KeyValuePair<string, string>("price", "asdasdas"),
                new KeyValuePair<string, string>("typeId", "-1")
            });

            var loginUserData = LoginUser("test", "testtest");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginUserData.Access_Token);
            var httpResponse = client.PutAsync(endpoint, mealEditedContent).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        }
        
        [TestMethod]
        public void EditMealWithoutBeingLogged_ShouldReturn401Unauthorized()
        {
            var context = new RestaurantsContext();
            var meal = context.Meals.FirstOrDefault(m => m.Name == "Test meal");

            if (meal == null)
            {
                Assert.Fail("Cannot perform test - no such meal in DB");
            }

            var endpoint = string.Format("api/meals/{0}", meal.Id);

            var mealEditedContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("name", "test edited"),
                new KeyValuePair<string, string>("price", "15"),
                new KeyValuePair<string, string>("typeId", "3")
            });

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "-1");
            var httpResponse = client.PutAsync(endpoint, mealEditedContent).Result;

            Assert.AreEqual(HttpStatusCode.Unauthorized, httpResponse.StatusCode);
        }

        public static HttpResponseMessage RegisterUserHttpPost(string username, string password, string email)
        {
            var postContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("confirmpassword", password),
                new KeyValuePair<string, string>("email", email)
            });
            var httpResponse = client.PostAsync("/api/user/register", postContent).Result;
            return httpResponse;
        }

        public static HttpResponseMessage LoginUserHttpPost(string username, string password)
        {
            var postContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("recipientUsername", username),
                new KeyValuePair<string, string>("password", password)
            });
            var httpResponse = client.PostAsync("/api/user/login", postContent).Result;
            return httpResponse;
        }

        public static void RegisterUser(string username, string password, string email)
        {
            var postContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("confirmpassword", password),
                new KeyValuePair<string, string>("email", email)
            });
            var httpResponse = client.PostAsync("/api/account/register", postContent).Result;
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
        }

        public static UserSessionModel LoginUser(string username, string password)
        {
            var postContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            });
            var httpResponse = client.PostAsync("/api/account/login", postContent).Result;
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var userSession = httpResponse.Content.ReadAsAsync<UserSessionModel>().Result;
            return userSession;
        }

        private static void Seed()
        {
            var context = new RestaurantsContext();

            var username = "test";
            var password = "testtest";
            var email = "test@gmail.com";

            if (!context.Users.Any(u => u.UserName == username))
            {
                RegisterUser(username, password, email);
            }

            var user = context.Users.Where(u => u.UserName == username).FirstOrDefault();

            var town = context.Towns.FirstOrDefault();
            if (town == null)
            {
                town = new Town()
                {
                    Name = "Test town1"
                };
            }

            var restaurant = context.Restaurants.FirstOrDefault(r => r.OwnerId == user.Id);
            if (restaurant == null)
            {
                restaurant = new Restaurant()
                {
                    Name = "Test restaurant 1",
                    Town = town,
                    Owner = user
                };
            }

            var meal = context.Meals.Where(m => m.Name == "Test meal").FirstOrDefault();

            if (meal == null)
            {
                context.Meals.Add(new Meal()
                {
                    Name = "Test meal",
                    Price = 123,
                    Restaurant = restaurant,
                    TypeId = 1
                });

                context.SaveChanges();
            }
            else
            {
                meal.Price = 123;
                meal.Restaurant = restaurant;
                meal.TypeId = 1;

                context.SaveChanges();
            }
        }
    }
}