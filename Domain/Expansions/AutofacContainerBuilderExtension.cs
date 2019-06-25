namespace Domain.Expansions
{
    using System.Linq;
    using Autofac;
    using Domain.BaseModels;
    using Domain.UserAccounts.AppRoles;
    using Domain.UserAccounts.AppUsers;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public static class AutofacContainerBuilderExtension
    {
        public static ContainerBuilder UseDomainConfigure(this ContainerBuilder builder)
        {
            var assembly = typeof(AutofacContainerBuilderExtension).Assembly;

            // Register IService
            builder.RegisterAssemblyTypes(assembly)
                .Where(m => m.IsClass && m.IsAbstract == false)
                .Where(m => m.GetInterface(typeof(IService).FullName) != default)
                .AsSelf()
                .InstancePerLifetimeScope();

            // UserStore
            builder.Register(
                m => new UserStore<AppUser>(m.Resolve<IUnitOfWork>().Context))
                .As<IUserStore<AppUser>>()
                .InstancePerLifetimeScope();

            // RoleStore
            builder.Register(
                m => new RoleStore<AppRole>(m.Resolve<IUnitOfWork>().Context))
                .As<IRoleStore<AppRole, string>>()
                .InstancePerLifetimeScope();

            // AppUserMananger
            builder.RegisterType<AppRoleMananger>()
                .AsSelf()
                .InstancePerLifetimeScope();

            return builder;
        }
    }
}
