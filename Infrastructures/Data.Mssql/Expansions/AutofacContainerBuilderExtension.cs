namespace Data.Mssql.Expansions
{
    using Autofac;
    using Domain.BaseModels;

    public static class AutofacContainerBuilderExtension
    {
        public static ContainerBuilder UseDataMssqlConfigure(this ContainerBuilder builder)
        {
            var assembly = typeof(AutofacContainerBuilderExtension).Assembly;

            // EF
            builder.RegisterAssemblyTypes(assembly)
                .Where(m => m.Name.EndsWith("DbContext"))
                .AsSelf()
                .InstancePerLifetimeScope();

            // Repository
            builder.RegisterAssemblyTypes(assembly)
                .Where(m => m.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // UnitOfWork
            builder.RegisterAssemblyTypes(assembly)
                .Where(m => m.Name.EndsWith(nameof(IUnitOfWork).Substring(1)))
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            return builder;
        }
    }
}
