namespace Twitter.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;

    using Repository;
    using Twitter.Models;

    public class TwitterSystemData : ITwitterSystemData
    {
        private ITwitterDbContext context;
        private IDictionary<Type, object> repositories;

        public TwitterSystemData()
            : this(new TwitterDbContext())
        {
        }

        public TwitterSystemData(ITwitterDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<ApplicationUser> ApplicationUsers
        {
            get { return GetRepository<ApplicationUser>(); }
        }

        public IGenericRepository<Message> Messages
        {
            get { return GetRepository<Message>(); }
        }

        public IGenericRepository<Notification> Notifications
        {
            get { return GetRepository<Notification>(); }
        }

        public IGenericRepository<Tweet> Tweets
        {
            get { return GetRepository<Tweet>(); }
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