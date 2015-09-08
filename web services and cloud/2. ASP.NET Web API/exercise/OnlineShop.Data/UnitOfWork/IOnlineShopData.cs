namespace OnlineShop.Data.UnitOfWork
{
    using OnlineShop.Data.Repository;
    using Models;

    public interface IOnlineShopData
    {
        IRepository<Ad> Ads { get; }

        IRepository<AdType> AdTypes { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<Category> Categories { get; }

        int SaveChanges();
    }
}