using JobTrail.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobTrail.Data
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly JTContext _context;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(JTContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            IEnumerable<string> includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if(includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public async virtual Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter, IEnumerable<string> includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.SingleAsync(filter);
        }

        public async virtual Task<TEntity> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async virtual Task Insert(TEntity entity, bool saveToDb = true)
        {
            await dbSet.AddAsync(entity);

            if (saveToDb)
            {
                await SaveDbChanges();
            }
        }

        public async virtual Task Delete(Guid id, bool saveToDb = true)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            await Delete(entityToDelete, saveToDb);
        }

        public async virtual Task Delete(TEntity entityToDelete, bool saveToDb = true)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);

            if (saveToDb)
            {
                await SaveDbChanges();
            }
        }

        public async virtual Task Update(TEntity entityToUpdate, bool saveToDb = true)
        {
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;

            if(saveToDb)
            {
                await SaveDbChanges();
            }
        }

        public async virtual Task SaveDbChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
