using BugTracker.Data.Models;
using BugTracker.RestServices.Controllers;
using BugTracker.RestServices.Models.BindingModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace BugTracker.Tests
{
    [TestClass]
    public class BugControllerTests
    {
        [TestMethod]
        public void EditExistingBug_ShouldChangeOnlySentData()
        {
            // Arange
            var fakeBugs = new List<Bug>
            {
                new Bug()
                {
                    Id = 1,
                    Title = "Bug #1",
                    Description = "Bug description",
                    DateCreated = DateTime.Now
                },
                new Bug()
                {
                    Id = 2,
                    Title = "Bug #2",
                    Description = "Bug description",
                    DateCreated = DateTime.Now
                },
            };

            var fakeBugsRepository = new FakeBugsRepository(fakeBugs);

            var fakeUnitOfWork = new FakeUnitOfWork(fakeBugsRepository);

            var newTitle = "Changed" + DateTime.Now.Ticks;
            var model = new EditBugBindingModel()
            {
                Title = newTitle
            };

            var oldDescription = fakeBugs[0].Description;
            var oldStatus = fakeBugs[0].Status;

            // Act
            var controller = new BugsController(fakeUnitOfWork);
            this.SetupController(controller);

            var response = controller.EditBug(1, model)
                .ExecuteAsync(CancellationToken.None).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(1, fakeUnitOfWork.SaveChangesCallCount);
            Assert.AreEqual(oldDescription, fakeBugs[0].Description);
            Assert.AreEqual(oldStatus, fakeBugs[0].Status);
            Assert.AreEqual(newTitle, fakeBugs[0].Title);
        }

        [TestMethod]
        public void EditNonExistingBug_ShouldReturn404NotFound()
        {
            // Arange
            var fakeBugs = new List<Bug>
            {
                new Bug()
                {
                    Id = 1,
                    Title = "Bug #1",
                    Description = "Bug description",
                    DateCreated = DateTime.Now
                },
                new Bug()
                {
                    Id = 2,
                    Title = "Bug #2",
                    Description = "Bug description",
                    DateCreated = DateTime.Now
                },
            };

            var fakeBugsRepository = new FakeBugsRepository(fakeBugs);

            var fakeUnitOfWork = new FakeUnitOfWork(fakeBugsRepository);

            var newTitle = "Changed" + DateTime.Now.Ticks;
            var model = new EditBugBindingModel()
            {
                Title = newTitle
            };

            // Act
            var controller = new BugsController(fakeUnitOfWork);
            this.SetupController(controller);

            var response = controller.EditBug(-1, model)
                .ExecuteAsync(CancellationToken.None).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        private void SetupController(ApiController controller)
        {
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
        }
    }
}