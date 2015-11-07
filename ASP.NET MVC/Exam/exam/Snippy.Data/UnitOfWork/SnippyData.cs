namespace Snippy.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Models;
    using Repositories;

    public class SnippyData : ISnippyData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories;

        public SnippyData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IRepository<Label> Labels
        {
            get { return this.GetRepository<Label>(); }
        }

        public IRepository<ProgrammingLanguage> ProgrammingLanguages
        {
            get { return this.GetRepository<ProgrammingLanguage>(); }
        }

        public IRepository<Snippet> Snippets
        {
            get { return this.GetRepository<Snippet>(); }
        }

        public IRepository<ApplicationUser> Users
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var repository = Activator.CreateInstance(
                    typeOfRepository, this.context);

                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
