namespace Data.Mssql
{
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using Domain.BaseModels;

    internal class UnitOfWork : IUnitOfWork
    {
        private readonly MainDbContext context;

        public UnitOfWork(MainDbContext context)
        {
            this.context = context;
        }

        DbContext IUnitOfWork.Context => context;

        int IUnitOfWork.Commit()
        {
            return context.SaveChanges();
        }

        Task<int> IUnitOfWork.CommitAsync()
        {
            return context.SaveChangesAsync();
        }

        void IUnitOfWork.EnableTransaction(Action action)
        {
            // use transaction
            using (var trans = context.Database.BeginTransaction())
            {
                action.Invoke();

                trans.Commit();
            }
        }
    }
}
