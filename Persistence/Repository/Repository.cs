using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using vega.Data.Repository;
using System.Linq;

namespace vega.Persistence.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;
        private DbSet<TEntity> _entities; 
        public Repository(DbContext context)
        {
            this.context = context;
            _entities = this.context.Set<TEntity>();

        }
        void IRepository<TEntity>.Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        void IRepository<TEntity>.AddRange(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        IEnumerable<TEntity> IRepository<TEntity>.Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        TEntity IRepository<TEntity>.Get(int id)
        {
            return _entities.Find(id);
        }

        IEnumerable<TEntity> IRepository<TEntity>.GetAll()
        {
            return _entities.ToList();
        }

        void IRepository<TEntity>.Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        void IRepository<TEntity>.RemoveRange(TEntity entity)
        {
            _entities.RemoveRange(entity);
        }

        TEntity IRepository<TEntity>.SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }
    }
}