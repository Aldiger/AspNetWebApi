using Assecor.Data.Repositories;
using Assecor.Data.Repositories.Interfaces;
using Assecor.Services.Interfaces;
using Assecor.Services.Services;
using Autofac;
namespace Assecor.WebApi.IocRegistration
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

			#region Register  Repository

			builder.RegisterType<IColorRepository>().As<ColorRepository>();
            builder.RegisterType<IPersonRepository>().As<PersonRepository>();
            builder.RegisterType<IColorService>().As<ColorService>();

            builder.RegisterType<IPersonService>().As<PersonService>();
            

            #endregion
        }
    }
}