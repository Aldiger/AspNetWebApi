using Assecor.Services.Dto;
using Assecor.Services.Interfaces;
using Autofac;
using EagleTM.UPE.Services;



namespace Assecor.Services.Services
{
	public static class Startup
	{
	    public static void Configure(ContainerBuilder builder, AppSettingsDto settings)
	    {
	        AppSettings.Init(settings);

	        Data.StartUp.Configure(builder, AppSettings.UpExchangeConnectionString);

	        builder.RegisterType<PersonService>().As<IPersonService>();
            builder.RegisterType<ColorService>().As<IColorService>();
        }
	}
}