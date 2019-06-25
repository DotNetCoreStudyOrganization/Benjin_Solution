namespace Domain.BaseModels
{
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        DbContext Context { get; }

        int Commit();

        Task<int> CommitAsync();

        void EnableTransaction(Action action);
    }
}
