namespace Application.Tests.Models
{
    using System;
    using Application.BaseModels;
    using AutoMapper;
    using Domain.Tests;

    public class TestBindModel : AppBaseModel
    {
        private static readonly IMapper MapperObj = GetMapper<MappingProfile>();

        public Guid Id { get; set; }

        public string Title { get; set; }

        internal Test ToEntity(Test entity = default)
        {
            if (entity == default)
            {
                entity = MapperObj.Map<Test>(this);
            }
            else
            {
                MapperObj.Map(this, entity);
            }

            return entity;
        }

        private class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Test, TestBindModel>();
            }
        }
    }
}
