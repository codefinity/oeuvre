using Autofac;
using Domaina.CQRS;
using Domaina.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;

namespace Oeuvre.Modules.ContentCreation.Infrastructure.Configuration.DataAccess
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
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<ContentCreationContext>();
                    dbContextOptionsBuilder.UseSqlServer(databaseConnectionString);

                    dbContextOptionsBuilder
                        .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();

                    dbContextOptionsBuilder.EnableSensitiveDataLogging();

                    return new ContentCreationContext(dbContextOptionsBuilder.Options, loggerFactory);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();


            var infrastructureAssembly = typeof(ContentCreationContext).Assembly;

            builder.RegisterAssemblyTypes(infrastructureAssembly)
                    .Where(type => type.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope()
                    .FindConstructorsWith(new AllConstructorFinder());
        }
    }
}
