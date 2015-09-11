using BidSystem.Data.Models;
using BidSystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidSystem.Data.UnitOfWork
{
    public interface IBidSystemData
    {
        IRepository<Offer> Offers { get; }

        IRepository<Bid> Bids { get; }

        IRepository<User> Users { get; }

        int SaveChanges();
    }
}