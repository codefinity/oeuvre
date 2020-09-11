using Domaina.Infrastructure.EMails;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.IntegrationTests.SeedWork
{
    public static class TestConfigurationVariables
    {
        public static string ConnectionString { get; set; }

        public static EmailsConfiguration EmailsConfiguration { get; set; }

    }
}
