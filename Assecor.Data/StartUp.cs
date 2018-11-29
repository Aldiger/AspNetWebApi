using Assecor.Data.Core;
using Assecor.Data.Core.Interfaces;
using Assecor.Data.Repositories;
using Assecor.Data.Repositories.Interfaces;
using Autofac;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Assecor.Data
{
    public class StartUp
    {
        private static string _connectionString;

        //TODO need to parameterize connectiong string
        public static void Configure(ContainerBuilder builder, string connectionString)
        {

            _connectionString = connectionString;

            builder.RegisterType<ContextFactory>().As<IContextFactory>()
                .InstancePerLifetimeScope()
                .WithParameter("cnString", connectionString);

            builder.RegisterType<PersonRepository>().As<IPersonRepository>();
            builder.RegisterType<ColorRepository>().As<IColorRepository>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }

        public static void Configure(ContainerBuilder builder, string serverName, string databaseName, string userName, string password)
        {
            var connectionString = $"Data Source={serverName};Initial Catalog={databaseName};UID={userName};PWD={password}";
            //var connectionStringEdmx = $"metadata=res://*/UPExchangeModel.csdl|res://*/UPExchangeModel.ssdl|res://*/UPExchangeModel.msl;provider=System.Data.SqlClient;provider connection string=\"data source={serverName};initial catalog={databaseName};integrated security=false;User ID={userName};Password={password};multipleactiveresultsets=True;App=EntityFramework\"";

            Configure(builder, connectionString);
        }

        internal static SqlConnection DbConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
