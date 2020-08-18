using Autofac;
using Domaina.Application;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration.DataAccess;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration.Domain;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration.Logging;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration.Mediation;
using Serilog;
using Serilog.AspNetCore;


namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration
{
    public class IdentityAccessStartup
    {
        private static IContainer container;

        public static void Initialize(string connectionString
            ,IExecutionContextAccessor executionContextAccessor
            ,ILogger logger
            //,EmailsConfiguration emailsConfiguration,
            //,string textEncryptionKey,
            //,IEmailSender emailSender
            )
        {
           var moduleLogger = logger.ForContext("Module", "IdentityAccess");

            ConfigureCompositionRoot(connectionString
                                       ,executionContextAccessor
                                       ,logger
                                        //,emailsConfiguration
                                        //,textEncryptionKey
                                        //,emailSender
                                        );

            //QuartzStartup.Initialize(moduleLogger);

            //EventsBusStartup.Initialize(moduleLogger);
        }

        private static void ConfigureCompositionRoot(
            string connectionString
            ,IExecutionContextAccessor executionContextAccessor
            ,ILogger logger
            //,EmailsConfiguration emailsConfiguration
            //,string textEncryptionKey
            //,IEmailSender emailSender
            )
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "IdentityAccess")));

            

            var loggerFactory = new SerilogLoggerFactory(logger);
            containerBuilder.RegisterModule(
                                        new DataAccessModule(connectionString
                                                                , loggerFactory
                                        ));

            containerBuilder.RegisterModule(new DomainModule());
            //containerBuilder.RegisterModule(new ProcessingModule());
            //containerBuilder.RegisterModule(new EventsBusModule());
            containerBuilder.RegisterModule(new MediatorModule());
            //containerBuilder.RegisterModule(new OutboxModule());
            //containerBuilder.RegisterModule(new QuartzModule());
            //containerBuilder.RegisterModule(new EmailModule(emailsConfiguration, emailSender));
            //containerBuilder.RegisterModule(new SecurityModule(textEncryptionKey));

            containerBuilder.RegisterInstance(executionContextAccessor);

            container = containerBuilder.Build();

            IdentityAccessCompositionRoot.SetContainer(container);
        }
    }
}
