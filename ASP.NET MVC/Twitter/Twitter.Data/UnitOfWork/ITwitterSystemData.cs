namespace Twitter.Data.UnitOfWork
{
    using Twitter.Models;
    using Twitter.Data.Repository;

    public interface ITwitterSystemData
    {
        IGenericRepository<Tweet> Tweets { get; }

        IGenericRepository<Profile> Profiles { get; }

        IGenericRepository<Message> Messages { get; }

        IGenericRepository<Notification> Notifications { get; }

        IGenericRepository<ApplicationUser> ApplicationUsers { get; }

        void SaveChanges();
    }
}