using JewelryBox.Infrastructure.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelryBox.Infrastructure.Data.Abstractions
{
    public abstract class ARepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext db;

        public ARepository(IDbFactory factory)
        {
            db = factory.Create();
        }

        public virtual void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().AddRange(entities);
        }

        public virtual TEntity Get<TKey>(TKey key)
        {
            var entity = db.Set<TEntity>()
                .Find(key);

            return entity;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return db.Set<TEntity>();
        }

        public virtual void Remove<TKey>(TKey key)
        {
            var entity = db.Set<TEntity>().Find(key);
            db.Set<TEntity>().Remove(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().RemoveRange(entities);
        }

        public virtual void Save()
        {
            db.SaveChanges();
        }
    }
}
