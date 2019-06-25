namespace Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain.BaseModels;

    internal class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        private readonly DbContext context;

        private readonly DbSet<TEntity> entityDbSet;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            context = unitOfWork.Context;

            entityDbSet = unitOfWork.Context.Set<TEntity>();
        }

        public TEntity Get(Guid id, bool tracking = false)
        {
            var query = tracking ? entityDbSet : entityDbSet.AsNoTracking();

            return query.SingleOrDefault(m => m.Id == id);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, bool tracking = false)
        {
            var query = predicate == null ? entityDbSet : entityDbSet.Where(predicate);

            query = tracking ? query : query.AsNoTracking();

            return query;
        }

        public void CreateOrUpdate(TEntity entity)
        {
            if (entity == null)
            {
                return;
            }

            var isExist = entityDbSet.AsNoTracking().Where(m => m.Id == entity.Id).Count() > 0;

            if (isExist)
            {
                entityDbSet.Attach(entity);

                context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                context.Entry(entity).State = EntityState.Added;
            }
        }

        public void Remove(TEntity entity)
        {
            var entityId = entity?.Id ?? Guid.Empty;

            if (entityDbSet.Where(m => m.Id == entityId).Count() == 0)
            {
                return;
            }

            entityDbSet.Attach(entity);
            entityDbSet.Remove(entity);
        }

        public void Remove(Guid id)
        {
            var entity = entityDbSet.Find(id);

            if (entity == null)
            {
                return;
            }

            entityDbSet.Attach(entity);
            entityDbSet.Remove(entity);
        }
    }
}
