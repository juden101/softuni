namespace News.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private NewsEntities context;
        private IDbSet<T> dbSet;

        public GenericRepository()
            : this(new NewsEntities())
        {
        }

        public GenericRepository(NewsEntities context)
        {
            this.context = context;
            this.dbSet = this.context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.dbSet.AsQueryable();
        }

        public T GetById(object id)
        {
            return this.dbSet.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
            //this.DbSet.Add(entity);
            //return entity;
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
            //this.DbSet.AddOrUpdate(entity);
            //return entity;
        }

        public void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            //this.DbSet.Remove(entity);
            //return entity;
        }

        public T Delete(object id)
        {
            var entity = this.GetById(id);
            this.Delete(entity);
            return entity;
        }


        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            entry.State = state;
        }
    }
}