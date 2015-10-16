namespace Twitter.Data.UnitOfWork
{
    using Twitter.Models;
    using Twitter.Data.Repository;

    public interface ITwitterSystemData
    {
        IGenericRepository<Tweet> Tweets { get; }

        IGenericRepository<ApplicationUser> ApplicationUsers { get; }

        void SaveChanges();
    }
}