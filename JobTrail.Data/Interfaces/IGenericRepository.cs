using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JobTrail.Data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task Delete(Guid id);
        void Delete(TEntity entityToDelete);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        Task<TEntity> GetByID(Guid id);
        Task Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
    }
}