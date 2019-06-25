namespace Application.BaseModels
{
    using AutoMapper;

    public abstract class AppBaseModel
    {
        protected static IMapper GetMapper<TProfile>() where TProfile : Profile, new()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<TProfile>());

            foreach (var typeMap in Mapper.Configuration.GetAllTypeMaps())
            {
                mapperConfiguration.RegisterTypeMap(typeMap);
            }

            return mapperConfiguration.CreateMapper();
        }
    }
}
