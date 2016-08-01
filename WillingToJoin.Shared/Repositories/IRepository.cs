using System;
using System.Linq;
using System.Linq.Expressions;

namespace WillingToJoin.Shared.Context
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(Guid id);
        TEntity Find(Expression<Func<TEntity, bool>> match);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> match);
        TEntity Add(TEntity t);
        TEntity Update(TEntity updated, int key);
        void Delete(TEntity t);
        int Count();
    }
}