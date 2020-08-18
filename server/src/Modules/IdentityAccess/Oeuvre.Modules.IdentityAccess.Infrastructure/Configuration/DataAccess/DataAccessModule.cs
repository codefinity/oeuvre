using Autofac;
using Domaina.Application.Data;
using Domaina.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration.DataAccess
{
    internal class DataAccessModule : Autofac.Module
    {
        private readonly string databaseConnectionString;
        private readonly ILoggerFactory loggerFactory;

        internal DataAccessModule(string databaseConnectionString
                                    , ILoggerFactory loggerFactory)
        {
            this.databaseConnectionString = databaseConnectionString;
            this.loggerFactory = loggerFactory;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                    .As<ISqlConnectionFactory>()
                    .WithParameter("connectionString", databaseConnectionString)
                    .InstancePerLifetimeScope();


            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<IdentityAccessContext>();
                    dbContextOptionsBuilder.UseSqlServer(databaseConnectionString);

                    dbContextOptionsBuilder
                        .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                    dbContextOptionsBuilder.EnableSensitiveDataLogging();

                    return new IdentityAccessContext(dbContextOptionsBuilder.Options, loggerFactory);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();


            var infrastructureAssembly = typeof(IdentityAccessContext).Assembly;

            builder.RegisterAssemblyTypes(infrastructureAssembly)
                    .Where(type => type.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope()
                    .FindConstructorsWith(new AllConstructorFinder());
        }
    }
}
