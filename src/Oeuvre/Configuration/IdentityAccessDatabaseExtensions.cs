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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Domaina.Infrastructure;

namespace Oeuvre.Configuration
{
    internal static class IdentityAccessDatabaseExtensions
    {
        internal static IServiceCollection AddIdentityAcessDatabase(this IServiceCollection services,
                                                                        IConfiguration configuration)
        {
            //--Database
            //string connectionString = configuration.GetConnectionString("DefaultConnection");
            //services.AddEntityFrameworkNpgsql();
            //services.AddPostgresDbContext<UserAccessContext>(connectionString);
            //services.AddScoped<DbConnection>(c => new NpgsqlConnection(connectionString));
            //--

            services.AddDbContext<UserAccessContext>(options =>
                options
                .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>() 
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        internal static IApplicationBuilder UseIdentityAcessDatabase(this IApplicationBuilder app)
        {
            //--Database
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<UserAccessContext>();
                context.Database.EnsureCreated();
            }
            //--

            return app;
        }

    }
}
