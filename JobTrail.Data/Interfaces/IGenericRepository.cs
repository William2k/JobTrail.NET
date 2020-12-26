﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobTrail.Data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task Delete(Guid id, bool saveToDb = true);
        Task Delete(TEntity entityToDelete, bool saveToDb = true);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, IEnumerable<string> includeProperties = null);
        Task<TEntity> GetByID(Guid id);
        Task Insert(TEntity entity, bool saveToDb = true);
        Task Update(TEntity entityToUpdate, bool saveToDb = true);
    }
}