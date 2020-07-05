using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Npgsql;
using System.Data.Common;
using Oeuvre.Modules.IdentityAccess.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Oeuvre.Configuration
{
    internal static class IdentityAccessDatabaseExtensions
    {
        internal static IServiceCollection AddIdentityAcessDatabase(this IServiceCollection services,
                                                                        IConfiguration configuration)
        {
            //--Database
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddEntityFrameworkNpgsql();
            services.AddPostgresDbContext<IdentityAccessDBContext>(connectionString);
            services.AddScoped<DbConnection>(c => new NpgsqlConnection(connectionString));
            //--


            return services;
        }

        internal static IApplicationBuilder UseIdentityAcessDatabase(this IApplicationBuilder app)
        {
            //--Database
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<IdentityAccessDBContext>();
                context.Database.EnsureCreated();
            }
            //--

            return app;
        }

    }
}
