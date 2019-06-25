namespace Application.Expansions
{
    using System.Linq;
    using Application.BaseModels;
    using Autofac;

    public static class AutofacContainerBuilderExtension
    {
        public static ContainerBuilder UseApplicationConfigure(this ContainerBuilder builder)
        {
            var assembly = typeof(AutofacContainerBuilderExtension).Assembly;
            
            // Register IAppService
            builder.RegisterAssemblyTypes(assembly)
                .Where(m => m.IsClass && m.IsAbstract == false)
                .Where(m => m.GetInterface(typeof(IAppService).FullName) != default)
                .AsSelf()
                .InstancePerLifetimeScope();

            return builder;
        }
    }
}
