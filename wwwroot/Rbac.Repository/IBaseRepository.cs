using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Rbac.Repository
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        int BulkCreate(List<TEntity> entities);
        int Create(TEntity entity);
        int Delete(Expression<Func<TEntity, bool>> predicate);
        int Delete(TKey key);
        List<TEntity> GetAll();
        TEntity GetEntity(Expression<Func<TEntity, bool>> predicate);
        TEntity GetEntity(TKey key);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate = null);
        int Update(TEntity entity);
    }
}