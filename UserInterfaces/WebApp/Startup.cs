[assembly: Microsoft.Owin.OwinStartup(typeof(WebApp.Startup))]

namespace WebApp
{
    using System.Reflection;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Http;
    using Autofac;
    using Autofac.Integration.WebApi;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security.Cookies;
    using Owin;

    public class Startup : Application.AppStartup
    {
        protected override IPrincipal CurrentPrincipal => HttpContext.Current?.User;

        public void Configuration(IAppBuilder app)
        {
            var container = AppConfiguration(app).Build();

            var config = new HttpConfiguration();

            WebApiConfig.Register(config);

            FilterConfig.Register(config);

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container)
                .UseAutofacWebApi(config)
                .UseWebApi(config);
        }

        protected override ContainerBuilder AppConfiguration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });

            var builder = base.AppConfiguration(app);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            return builder;
        }
    }
}
