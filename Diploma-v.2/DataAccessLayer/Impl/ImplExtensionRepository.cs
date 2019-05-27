using Core;
using DataAccessLayer.Interface.Extension;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Impl
{
    public class ImplExtensionRepository<TEntity> : ImplRepository<TEntity> , IExtensionRepository<TEntity> where TEntity : EntityBase
    {
        public ImplExtensionRepository(DbContext context) : base(context) { }

        public IQueryable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties);
        }

        public IQueryable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).Where(predicate).AsQueryable();
        }

        public IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return includeProperties
                .Aggregate(dbSet.AsNoTracking(), (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
