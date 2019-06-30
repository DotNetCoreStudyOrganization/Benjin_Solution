namespace Data.Mssql.Expansions
{
    using Autofac;
    using Domain.BaseModels;

    public static class AutofacContainerBuilderExtension
    {
        public static ContainerBuilder UseDataMssqlConfigure(this ContainerBuilder builder)
        {
            // Register MainDbContext
            builder.RegisterType<MainDbContext>().AsSelf().InstancePerLifetimeScope();

            // Register UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            // Type of IRepository
            var interfaceRepositoryType = typeof(IRepository<>);

            // Register Repository
            builder.RegisterAssemblyTypes(typeof(AutofacContainerBuilderExtension).Assembly)
                .Where(m => m.GetInterface(interfaceRepositoryType.FullName) != null)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            return builder;
        }
    }
}
