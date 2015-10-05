using System.Data.Entity;
using System.Linq;

namespace MoviesGallery.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class 
    {
        public GenericRepository(MoviesGalleryEntities context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected MoviesGalleryEntities Context { get; set; }

        protected IDbSet<T> DbSet { get; set; } 
        
        public IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public T GetById(T id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public void ChngeState(T entity, EntityState state)
        {
            throw new System.NotImplementedException();
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public void ChangeState(T entity, EntityState state)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = state;
        }
    }
}
