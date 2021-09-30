using Financiera.Persistence;
using Microsoft.EntityFrameworkCore;
using Positano.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Positano.Persistence
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal PositanoContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(PositanoContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet.MultipleInclude(includes);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return query.ToList();
        }


        public virtual TEntity  GetByPhone(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet.MultipleInclude(includes);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            TEntity entity = query.AsQueryable().FirstOrDefault();
            return entity;
        }

        public virtual IQueryable<TEntity> GetQueryable(
            Expression<Func<TEntity, bool>> filter = null,
             params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet.MultipleInclude(includes);

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query;
        }

        public virtual IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            return dbSet.MultipleInclude(includes).ToList();
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }


      
        public virtual TEntity GetByIdInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter).MultipleInclude(includes);
            }

            TEntity entity = query.AsQueryable().First();
            return entity;
        }

        public virtual void Insert(TEntity entity, bool commit = true)
        {
            dbSet.Add(entity);
            if (commit)
                Commit();
        }

        public virtual void Delete(object id, bool commit = true)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            if (commit)
                Commit();
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            Commit();
        }

        public virtual void Commit()
        {
            context.SaveChanges();
        }
    }
}
