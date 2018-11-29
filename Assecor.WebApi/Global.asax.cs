using Assecor.Services.Services;
using Assecor.WebApi.IocRegistration;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Assecor.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            Startup.Configure(builder, AppSettings.ToServicesAppSettingsDto());
            CustomRegister(builder);
        }
        private void CustomRegister(ContainerBuilder builder)
        {
            RegisterControllers(builder);
        }
        private static void RegisterModules(ContainerBuilder builder)
        {
            builder.RegisterModule(new WebModule());
        }

        private void RegisterControllers(ContainerBuilder builder)
        {
            // Register API controllers using assembly scanning.
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(typeof(Assecor.WebApi.Controllers.PersonController).Assembly)
.PropertiesAutowired();
            var container = builder.Build();

            // Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);
        }
    }
}
