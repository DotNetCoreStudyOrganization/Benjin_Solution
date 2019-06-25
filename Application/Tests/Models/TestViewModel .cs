namespace Application.Tests.Models
{
    using System;
    using Application.BaseModels;
    using AutoMapper;
    using Domain.Tests;

    public class TestViewModel : AppBaseModel
    {
        private static readonly IMapper MapperObj = GetMapper<MappingProfile>();

        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        internal static TestViewModel Create(Test entity) 
        {
            return MapperObj.Map<TestViewModel>(entity);
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
