using BugTracker.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracker.Data.Models;
using BugTracker.Data.Repositories;

namespace BugTracker.Tests
{
    class FakeUnitOfWork : IBugTrackerData
    {
        private IRepository<Bug> fakeBugRepository;

        private int saveChangesCallCount;

        public FakeUnitOfWork(IRepository<Bug> fakeBugRepository)
        {
            this.fakeBugRepository = fakeBugRepository;
        }

        public int SaveChangesCallCount
        {
            get { return this.saveChangesCallCount; }
            private set { this.saveChangesCallCount = value; }
        }

        public IRepository<Bug> Bugs
        {
            get { return this.fakeBugRepository; }
        }

        public IRepository<Comment> Comments
        {
            get;
        }

        public IRepository<User> Users
        {
            get;
        }

        public int SaveChanges()
        {
            this.SaveChangesCallCount++;
            return this.SaveChangesCallCount;
        }
    }
}
