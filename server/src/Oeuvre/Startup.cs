using System;
using System.Data.Common;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Validation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Oeuvre.Configuration;
using Oeuvre.Modules.IdentityAccess.API;
using Oeuvre.Modules.IdentityAccess.API.Controller;
using Oeuvre.Modules.IdentityAccess.Application;
using Oeuvre.Modules.IdentityAccess.Application.IdentityServer;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser;
using Oeuvre.Modules.IdentityAccess.Infrastructure;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration;
using Serilog;
using Serilog.Formatting.Compact;

namespace Oeuvre
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            //Configuration = configuration;

            this.configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                                    //.AddUserSecrets<Startup>()
                                    .Build();
        }

        //public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Changed as per reference project
            //services.AddControllersWithViews();
            services.AddControllers();

           

            ConfigureIdentityServer(services);


            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.Configure<KestrelServerOptions>(configuration.GetSection("Kestrel"));

            //services.AddIdentityAcessDatabase(Configuration);

            //Delete once DB operations are running
            ////--Database
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");
            //services.AddEntityFrameworkNpgsql();
            //services.AddPostgresDbContext<IdentityAccessDBContext>(connectionString);
            //services.AddScoped<DbConnection>(c => new NpgsqlConnection(connectionString));
            ////--

            services.AddSwaggerDocumentation();

            //services.AddMediatR(typeof(Startup));

            //------Dependency Injection
            //services.AddScoped<IUserAccessModule, UserAccessModule>();
            //------

            //var containerBuilder = new ContainerBuilder();
            //containerBuilder.Populate(services);
            //containerBuilder.RegisterModule(new UserAccessAutofacModule());

            //var container = containerBuilder.Build();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseIdentityAcessDatabase();

            //Delete once DB operations are running
            ////--Database
            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetRequiredService<IdentityAccessDBContext>();
            //    context.Database.EnsureCreated();
            //}
            ////--

            app.UseIdentityServer();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            //Remove this to see swagger UI
            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseReactDevelopmentServer(npmScript: "start");
            //    }
            //});

            app.UseSwaggerDocumentation();
        }

        private void ConfigureIdentityServer(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityServerConfig.GetApis())
                .AddInMemoryClients(IdentityServerConfig.GetClients())
                .AddInMemoryPersistedGrants()
                .AddProfileService<ProfileService>()
                .AddDeveloperSigningCredential();

            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, x =>
                {
                    x.Authority = "http://localhost:5000";
                    x.ApiName = "oeuvreAPI";
                    x.RequireHttpsMetadata = false;
                });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Add any Autofac modules or registrations.
            // This is called AFTER ConfigureServices so things you
            // register here OVERRIDE things registered in ConfigureServices.
            //
            // You must have the call to AddAutofac in the Program.Main
            // method or this won't be called.
            builder.RegisterModule(new UserAccessAutofacModule());

            builder.RegisterType<Mediator>()
                                .As<IMediator>()
                                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            //builder.RegisterAssemblyTypes(typeof(MyType).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterType<RegisterNewUserCommandHandler>().AsImplementedInterfaces().InstancePerDependency();

            UserAccessStartup.Initialize(
                configuration.GetConnectionString("DefaultConnection")
                            //,executionContextAccessor,
                            //_logger,
                            //emailsConfiguration,
                            //this._configuration["Security:TextEncryptionKey"],
                            //null
                            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.


    }
}
