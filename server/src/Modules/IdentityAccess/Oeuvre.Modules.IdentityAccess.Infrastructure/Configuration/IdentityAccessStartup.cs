using Autofac;
using CompanyName.MyMeetings.Modules.UserAccess.Infrastructure.Configuration.Email;
using Domaina.Application;
using Domaina.Infrastructure.EMails;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration.DataAccess;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration.Domain;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration.InMemoryEventBus;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration.Logging;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration.Mediation;
using Serilog;
using Serilog.AspNetCore;
using Serilog.Formatting.Compact;
using System;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration
{
    public class IdentityAccessStartup
    {
        private static IContainer container;
        public static void Initialize(
            string connectionString
            , IExecutionContextAccessor executionContextAccessor
            //,ILogger logger
            ,EmailsConfiguration emailsConfiguration
            //,string textEncryptionKey,
            ,IEmailSender emailSender
            )
        {

            string identityAccessLogPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) 
                                            + "\\OeuvreLogs\\IdentityAccess\\IdentityAccess";


            ILogger moduleLogger = new LoggerConfiguration()
                                            .Enrich.FromLogContext()
                                            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{Module}] [{Context}] {Message:lj}{NewLine}{Exception}")
                                            .WriteTo.RollingFile(new CompactJsonFormatter(), identityAccessLogPath)
                                            .CreateLogger()
                                            .ForContext("Module", "IdentityAccess");

            ConfigureCompositionRoot(connectionString
                                        ,executionContextAccessor
                                        ,moduleLogger
                                        ,emailsConfiguration
                                        //,textEncryptionKey
                                        ,emailSender
                                        );

            //QuartzStartup.Initialize(moduleLogger);

            InMemoryEventsBusStartup.Initialize(moduleLogger);
        }

        private static void ConfigureCompositionRoot(
            string connectionString
                ,IExecutionContextAccessor executionContextAccessor
                ,ILogger moduleLogger
                ,EmailsConfiguration emailsConfiguration
                //,string textEncryptionKey
                ,IEmailSender emailSender
            )
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new LoggingModule(moduleLogger));

            var loggerFactory = new SerilogLoggerFactory(moduleLogger);

            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new DomainModule());
            containerBuilder.RegisterModule(new InMemoryEventsBusModule());
            containerBuilder.RegisterModule(new MediatorModule());
            containerBuilder.RegisterModule(new EmailModule(emailsConfiguration, emailSender));

            //containerBuilder.RegisterModule(new ProcessingModule());
            //containerBuilder.RegisterModule(new OutboxModule());
            //containerBuilder.RegisterModule(new QuartzModule());
            //containerBuilder.RegisterModule(new SecurityModule(textEncryptionKey));

            containerBuilder.RegisterInstance(executionContextAccessor);

            container = containerBuilder.Build();

            IdentityAccessCompositionRoot.SetContainer(container);
        }
    }
}
