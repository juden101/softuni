using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using News.Data.Repositories;
using News.Data;

namespace News.Tests.Repositories.Tests
{
    [TestClass]
    public class NewsRepositoryTests
    {
        private static TransactionScope tran;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void AddBug_WhenBugIsAddedToDb_ShouldReturnBug()
        {
            // Arrange -> prapare the objects
            var repo = new Data.Repositories.GenericRepository(NewsEntities.Create());
            /*var bug = new Bug()
            {
                Text = "Sample New Bug",
                DateCreated = DateTime.Now,
                Status = BugStatus.New
            };

            // Act -> perform some logic
            repo.Add(bug);
            repo.SaveChanges();

            // Assert -> validate the results
            var bugFromDb = repo.Find(bug.Id);

            Assert.IsNotNull(bugFromDb);
            Assert.AreEqual(bug.Text, bugFromDb.Text);
            Assert.AreEqual(bug.Status, bugFromDb.Status);
            Assert.AreEqual(bug.DateCreated, bugFromDb.DateCreated);
            Assert.IsTrue(bugFromDb.Id != 0);*/
        }
    }
}
