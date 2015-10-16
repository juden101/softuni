﻿namespace Twitter.Data.Repository
{
    using System.Linq;
    using System.Linq.Expressions;
    using System;

    public interface IGenericRepository<T>
    {
        IQueryable<T> All();

        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        T GetById(object id);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);
    }
}