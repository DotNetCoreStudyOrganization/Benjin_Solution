namespace Application
{
    using System.Collections.Generic;
    using System.Security.Principal;
    using Application.Expansions;
    using Autofac;
    using AutoMapper;
    using Data.Mssql.Expansions;
    using Domain.Expansions;
    using Domain.UserAccounts.AppUsers;
    using Owin;
    using X.PagedList;

    public abstract class AppStartup
    {
        protected abstract IPrincipal CurrentPrincipal { get; }

        protected virtual ContainerBuilder AppConfiguration(IAppBuilder app)
        {
            AutoMapperConfigure();

            var builder = new ContainerBuilder()
                .UseDomainConfigure()
                .UseDataMssqlConfigure()
                .UseApplicationConfigure();
            
            // AppUserMananger
            builder.RegisterType<AppUserMananger>()
                .AsSelf()
                .OnActivated(m => m.Instance.InitCurrentPrincipal(CurrentPrincipal))
                .InstancePerLifetimeScope();

            return builder;
        }

        private void AutoMapperConfigure()
        {
            var configurationExpression = new AutoMapper.Configuration.MapperConfigurationExpression();

            configurationExpression.AddProfile<PagedListMappingProfile>();

            Mapper.Initialize(configurationExpression);
        }

        private class PagedListMappingProfile : Profile
        {
            public PagedListMappingProfile()
            {
                CreateMap(typeof(IPagedList<>), typeof(IPagedList<>)).ConvertUsing(typeof(PagedListTypeConverter<,>));
            }

            private class PagedListTypeConverter<TSource, TDestination> : ITypeConverter<IPagedList<TSource>, IPagedList<TDestination>>
            {
                IPagedList<TDestination> ITypeConverter<IPagedList<TSource>, IPagedList<TDestination>>.Convert(IPagedList<TSource> source, IPagedList<TDestination> destination, ResolutionContext context)
                {
                    var pagedList = source.GetMetaData();

                    var superset = context.Mapper.Map<IEnumerable<TDestination>>(source);

                    return new PagedList<TDestination>(pagedList, superset);
                }
            }
        }
    }
}
