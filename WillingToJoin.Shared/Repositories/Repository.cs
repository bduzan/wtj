using System;
using System.Linq;
using System.Linq.Expressions;
using WillingToJoin.Shared.Context;

namespace WillingToJoin.Shared.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DatabaseContext Context;

        public Repository(DatabaseContext context)
        {
            Context = context;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        public virtual TEntity Get(Guid id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> match)
        {
            return Context.Set<TEntity>().SingleOrDefault(match);
        }

        public virtual IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
        {
            return Context.Set<TEntity>().Where(match);
        }

        public virtual TEntity Add(TEntity t)
        {
            Context.Set<TEntity>().Add(t);
            Context.SaveChanges();
            return t;
        }

        public virtual TEntity Update(TEntity updated, int key)
        {
            if (updated == null)
                return null;

            TEntity existing = Context.Set<TEntity>().Find(key);
            if (existing != null)
            {
                Context.Entry(existing).CurrentValues.SetValues(updated);
                Context.SaveChanges();
            }
            return existing;
        }

        public virtual void Delete(TEntity t)
        {
            Context.Set<TEntity>().Remove(t);
            Context.SaveChanges();
        }

        public virtual int Count()
        {
            return Context.Set<TEntity>().Count();
        }
    }
}
