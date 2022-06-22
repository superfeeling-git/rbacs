using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Repository
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
        where TKey : struct
    {
        /*private readonly RbacDbContext db;

        public BaseRepository(RbacDbContext db)
        {
            this.db = db;
        }*/

        protected RbacDbContext db;

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Create(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            return db.SaveChanges();
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int BulkCreate(List<TEntity> entities)
        {
            foreach (var item in entities)
            {
                db.Set<TEntity>().Add(item);
            }
            return db.SaveChanges();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Update(TEntity entity)
        {
            db.Entry<TEntity>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges();
        }

        /// <summary>
        /// 单条删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Delete(TKey key)
        {
            var entity = db.Set<TEntity>().Find(key);
            db.Remove(entity);
            return db.SaveChanges();
        }

        /// <summary>
        /// 单条删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = db.Set<TEntity>().Where(predicate);
            db.Remove(entity);
            return db.SaveChanges();
        }

        /// <summary>
        /// 返回单件数据
        /// </summary>
        /// <returns></returns>
        public TEntity GetEntity(TKey key)
        {
            return db.Set<TEntity>().Find(key);
        }

        /// <summary>
        /// 返回单件数据
        /// </summary>
        /// <returns></returns>
        public TEntity GetEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public List<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Set<TEntity>().Where(predicate).ToList();
        }

        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Set<TEntity>().Where(predicate);
        }
    }
}
