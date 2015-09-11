using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Owin.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BugTracker.RestServices;
using Owin;
using System.Net.Http;
using System.Net;
using System.Net.Http.Formatting;
using BugTracker.Data;
using BugTracker.Data.Models;
using BugTracker.RestServices.Models.ViewModels;

namespace BugTracker.Tests
{
    [TestClass]
    public class CommentsIntegrationTests
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
        public void GetBug_ShouldReturn200OK_ExistingBug()
        {
            var context = new BugTrackerDbContext();
            var existingBug = context.Bugs.FirstOrDefault();

            if (existingBug == null)
            {
                Assert.Fail("Cannot perform test - no bugs in DB");
            }

            var endpoint = string.Format("api/bugs/{0}/comments", existingBug.Id);
            var response = client.GetAsync(endpoint).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var comments = response.Content.ReadAsAsync<List<CommentViewModel>>().Result;

            foreach (var comment in comments)
            {
                Assert.IsNotNull(comment.Text);
                Assert.AreNotEqual(comment.Id, 0);
            }
        }

        [TestMethod]
        public void GetBug_ShouldReturn404_NonExistingBug()
        {
            var endpoint = string.Format("api/bugs/{0}/comments", -1);
            var response = client.GetAsync(endpoint).Result;

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        private static void Seed()
        {
            var context = new BugTrackerDbContext();

            if (!context.Bugs.Any())
            {
                context.Bugs.Add(new Bug()
                {
                    Title = "Bug #1",
                    Description = "First bug",
                    DateCreated = DateTime.Now
                });

                context.SaveChanges();
            }
        }
    }
}
