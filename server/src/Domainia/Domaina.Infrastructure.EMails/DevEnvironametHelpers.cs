using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Domaina.Infrastructure.EMails
{
    public static class DevEnvironametHelpers
    {
        public static void InDevEnvCreateTestMailFolderIfNotExists(string path)
        {
            var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development;

            if (isDevelopment)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

            }
        }
    }
}
