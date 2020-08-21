using Autofac;
using Domaina.Application;
using Domaina.Infrastructure.EventBus;
using Oeuvre.Modules.ContentCreation.Infrastructure.Configuration.DataAccess;
using Oeuvre.Modules.ContentCreation.Infrastructure.Configuration.InMemoryEventBus;
using Oeuvre.Modules.ContentCreation.Infrastructure.Configuration.Logging;
using Oeuvre.Modules.ContentCreation.Infrastructure.Configuration.Mediation;
using Serilog;
using Serilog.AspNetCore;
using Serilog.Formatting.Compact;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Infrastructure.Configuration
{
    public class ContentCreationStartup
    {
        private static IContainer _container;
        private static ILogger logger;

        public static void Initialize(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor
            //,ILogger logger,
            //,EmailsConfiguration emailsConfiguration
            //,IEventsBus eventsBus
            )
        {

            string identityAccessLogPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
                                + "\\OeuvreLogs\\ContentCreation\\ContentCreation";


            logger = new LoggerConfiguration()
                                            .Enrich.FromLogContext()
                                            .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{Module}] [{Context}] {Message:lj}{NewLine}{Exception}")
                                            .WriteTo.RollingFile(new CompactJsonFormatter(), identityAccessLogPath)
                                            .CreateLogger();

            var moduleLogger = logger.ForContext("Module", "ContentCreation");

            ConfigureCompositionRoot(
                connectionString,
                executionContextAccessor,
                moduleLogger
                //,emailsConfiguration,
                //eventsBus
                );

            //QuartzStartup.Initialize(moduleLogger);

            InMemoryEventsBusStartup.Initialize(moduleLogger);
        }

        private static void ConfigureCompositionRoot(
            string connectionString,
            IExecutionContextAccessor executionContextAccessor
            ,ILogger logger
            //,EmailsConfiguration emailsConfiguration,
            //,IEventsBus eventsBus
            )
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "ContentCreation")));

            var loggerFactory = new SerilogLoggerFactory(logger);

            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new InMemoryEventsBusModule());
            containerBuilder.RegisterModule(new MediatorModule());

            //containerBuilder.RegisterModule(new ProcessingModule());
            //containerBuilder.RegisterModule(new AuthenticationModule());

            //var domainNotificationsMap = new BiDictionary<string, Type>();
            //domainNotificationsMap.Add("MeetingGroupProposalAcceptedNotification", typeof(MeetingGroupProposalAcceptedNotification));
            //domainNotificationsMap.Add("MeetingGroupProposedNotification", typeof(MeetingGroupProposedNotification));
            //domainNotificationsMap.Add("MeetingGroupCreatedNotification", typeof(MeetingGroupCreatedNotification));
            //domainNotificationsMap.Add("MeetingAttendeeAddedNotification", typeof(MeetingAttendeeAddedNotification));
            //domainNotificationsMap.Add("MemberCreatedNotification", typeof(MemberCreatedNotification));
            //domainNotificationsMap.Add("MemberSubscriptionExpirationDateChangedNotification", typeof(MemberSubscriptionExpirationDateChangedNotification));
            //containerBuilder.RegisterModule(new OutboxModule(domainNotificationsMap));

            //containerBuilder.RegisterModule(new EmailModule(emailsConfiguration));
            //containerBuilder.RegisterModule(new QuartzModule());

            containerBuilder.RegisterInstance(executionContextAccessor);

            _container = containerBuilder.Build();

            ContentCreationCompositionRoot.SetContainer(_container);
        }
    }
}
