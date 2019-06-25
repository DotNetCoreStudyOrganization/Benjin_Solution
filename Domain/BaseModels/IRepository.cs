namespace Domain.BaseModels
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<TEntity> where TEntity : IAggregateRoot
    {
        TEntity Get(Guid id, bool tracking = true);
        
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = default, bool tracking = true);

        void CreateOrUpdate(TEntity entity);

        void Remove(TEntity entity);

        void Remove(Guid id);
    }
}
