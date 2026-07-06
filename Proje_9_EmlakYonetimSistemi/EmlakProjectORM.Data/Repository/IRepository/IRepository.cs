using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EmlakProjectORM.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string includeProperties = null);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, string includeProperties = null);
    }
}