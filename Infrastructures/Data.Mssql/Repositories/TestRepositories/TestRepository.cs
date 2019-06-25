namespace Data.Mssql.Repositories.TestRepositories
{
    using Data.Repositories;
    using Domain.BaseModels;
    using Domain.Tests;

    internal class TestRepository : BaseRepository<Test>, ITestRepository
    {
        public TestRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
