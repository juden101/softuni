namespace News.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    public interface IGenericRepository<T>
    {
        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void ChangeState(T entity, EntityState state);

        int SaveChanges();
    }
}