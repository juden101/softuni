﻿namespace SportSystem.Data.UnitOfWork
{
    using SportSystem.Data.Repositories;
    using SportSystem.Models;

    public interface ISportSystemData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Team> Teams { get; }

        IRepository<Player> Players { get; }

        IRepository<Match> Matches { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Bet> Bets { get; }

        IRepository<Vote> Votes { get; }

        int SaveChanges();
    }
}
