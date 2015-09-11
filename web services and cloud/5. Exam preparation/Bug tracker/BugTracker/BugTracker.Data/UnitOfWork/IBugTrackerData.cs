using BugTracker.Data.Models;
using BugTracker.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Data.UnitOfWork
{
    public interface IBugTrackerData
    {
        IRepository<Bug> Bugs { get; }

        IRepository<Comment> Comments { get; }

        IRepository<User> Users { get; }

        int SaveChanges();
    }
}
