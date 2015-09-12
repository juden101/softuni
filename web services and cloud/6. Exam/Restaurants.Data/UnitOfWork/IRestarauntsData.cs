namespace Restaurants.Data.UnitOfWork
{
    using Restaurants.Models;
    using Restaurants.Data.Repositories;

    using Microsoft.AspNet.Identity;
    using Restauranteur.Models;

    public interface IRestaurantsData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Rating> Ratings { get; }

        IRepository<Town> Towns { get; }

        IRepository<Restaurant> Restaurants { get; }

        IRepository<Meal> Meals { get; }

        IRepository<MealType> MealTypes { get; }

        IRepository<Order> Orders { get; }

        void SaveChanges();
    }
}
