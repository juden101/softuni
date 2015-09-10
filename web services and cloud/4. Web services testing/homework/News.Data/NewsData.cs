namespace News.Data
{
    using System;
    using System.Collections.Generic;

    using News.Data.Repositories;
    using News.Models;

    public class NewsData : INewsData
    {
        private NewsEntities context;
        private IDictionary<Type, object> repositories;

        public NewsData()
            : this(new NewsEntities())
        {
        }

        public NewsData(NewsEntities context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<News> News
        {
            get { return GetRepository<News>(); }
        }

        public IGenericRepository<ApplicationUser> Users
        {
            get { return GetRepository<ApplicationUser>(); }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            var modelType = typeof(T);
            if (!this.repositories.ContainsKey(modelType))
            {
                var repositoryType = typeof(GenericRepository<T>);
                this.repositories.Add(modelType, Activator.CreateInstance(repositoryType, this.context));
            }

            return (IGenericRepository<T>)this.repositories[modelType];
        }
    }
}
