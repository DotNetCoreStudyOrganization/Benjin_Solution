namespace Application.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Application.BaseModels;
    using Application.Tests.Models;
    using Domain.Tests;

    public class TestAppService : IAppService
    {
        private readonly TestService service;

        public TestAppService(TestService service)
        {
            this.service = service;
        }

        public TestViewModel Get(Guid id, bool tracking = false)
        {
            var entity = service.Get(id, tracking);

            return TestViewModel.Create(entity);
        }

        public IEnumerable<TestViewModel> GetAll()
        {
            var entites = service.GetAll(m => m.Title != string.Empty).ToList();

            return entites.Select(m => TestViewModel.Create(m));
        }

        public int CreateOrUpdate(TestBindModel model)
        {
            var entity = model.ToEntity();

            return service.CreateOrUpdate(entity, true);
        }
    }
}
