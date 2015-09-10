namespace News.Data
{
    using News.Data.Repositories;
    using News.Models;

    public interface INewsData
    {
        IGenericRepository<ApplicationUser> Users { get; }

        IGenericRepository<News> News { get; }

        void SaveChanges();
    }
}