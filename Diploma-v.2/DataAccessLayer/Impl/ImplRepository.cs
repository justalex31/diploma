using Core;
using DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Impl
{
    public class ImplRepository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
    {
        private readonly DbContext dbContext;
        protected DbSet<TEntity> dbSet;

        public ImplRepository(DbContext context)
        {
            dbContext = context;
            dbSet = dbContext.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            dbSet.Add(item);
        }

        public TEntity FindById(object id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<TEntity> Get()
        {
            return dbSet.AsNoTracking();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).AsQueryable();
        }

        public void Remove(TEntity item)
        {
            dbSet.Remove(item);
        }

        public void Update(TEntity item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
