namespace Domain.Tests
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain.BaseModels;

    public class TestService : IService
    {
        private readonly ITestRepository testRepository;
        private readonly IUnitOfWork unitOfWork;

        public TestService(
            ITestRepository testRepository,
            IUnitOfWork unitOfWork)
        {
            this.testRepository = testRepository;
            this.unitOfWork = unitOfWork;
        }

        public Test Get(Guid id, bool tracking = false)
        {
            return testRepository.Get(id, tracking);
        }

        public IQueryable<Test> GetAll(Expression<Func<Test, bool>> predicate = default, bool tracking = false)
        {
            return testRepository.GetAll(predicate, tracking);
        }

        public int CreateOrUpdate(Test entity, bool commit = false)
        {
            testRepository.CreateOrUpdate(entity);

            return commit ? unitOfWork.Commit() : -1;
        }
    }
}
