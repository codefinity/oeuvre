using Autofac;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration.Logging
{
    internal class LoggingModule : Autofac.Module
    {
        private readonly ILogger logger;

        internal LoggingModule(ILogger logger)
        {
            this.logger = logger;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(logger)
                    .As<ILogger>()
                    .SingleInstance();
        }
    }
}
