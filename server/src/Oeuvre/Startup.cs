using System;
using System.Data.Common;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Domaina.Application;
using IdentityServer4.AccessTokenValidation;
using IdentityServer4.Validation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Oeuvre.Modules.IdentityAccess.API;
using Oeuvre.Modules.IdentityAccess.API.Controller;
using Oeuvre.Modules.IdentityAccess.Application;
using Oeuvre.Modules.IdentityAccess.Application.IdentityServer;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration;
using Serilog;
using Serilog.Formatting.Compact;
using Microsoft.IdentityModel.Tokens;
using Oeuvre.Modules.ContentCreation.Infrastructure.Configuration;
using Oeuvre.Modules.ContentCreation.API.Controllers;
using Domania.Security.Authorization;
using Oeuvre.Modules.ContentCreation.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Microsoft.IdentityModel.Logging;
using Oeuvre.Modules.IdentityAccess.Application.Authorization;
using Domaina.Infrastructure.EMails;

namespace Oeuvre
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        //public IConfiguration Configuration { get; }
        //private static ILogger logger;
        private static ILogger loggerForApi;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            //Configuration = configuration;

            ConfigureLoggerForAPI();

            this.configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                                    //.AddUserSecrets<Startup>()
                                    .Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CORSPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //Changed as per reference project
            //services.AddControllersWithViews();
            services.AddControllers();

            services.AddSwaggerDocumentation();

            ConfigureIdentityServer(services);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IExecutionContextAccessor, ExecutionContextAccessor>();

            //From Reference Project. Check Later.
            //services.AddProblemDetails(x =>
            //{
            //    x.Map<InvalidCommandException>(ex => new InvalidCommandProblemDetails(ex));
            //    x.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionProblemDetails(ex));
            //});

            //-----Authorization
            services.AddAuthorization(options =>
            {
                options.AddPolicy(HasPermissionAttribute.HasPermissionPolicyName, policyBuilder =>
                {
                    policyBuilder.Requirements.Add(new HasPermissionAuthorizationRequirement());
                    policyBuilder.AddAuthenticationSchemes(IdentityServerAuthenticationDefaults.AuthenticationScheme);
                });
            });


            services.AddScoped<IAuthorizationHandler, HasPermissionAuthorizationHandler>();
            //-----

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.Configure<KestrelServerOptions>(configuration.GetSection("Kestrel"));

            //This will display errors for IdentityServer. Disable for production.
            IdentityModelEventSource.ShowPII = true;

        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new IdentityAccessAutofacModule());
            containerBuilder.RegisterModule(new ContentCreationAutofacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            var container = app.ApplicationServices.GetAutofacRoot();

            InitializeModules(container);

            app.UseCors("CORSPolicy");

            app.UseMiddleware<CorrelationMiddleware>();

            app.UseSwaggerDocumentation();

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

            app.UseAuthorization();

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
        }

        private void ConfigureIdentityServer(IServiceCollection services)
        {
            services.AddIdentityServer()
                        .AddInMemoryApiScopes(IdentityServerConfig.GetApiScopes())
                        .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                        .AddInMemoryApiResources(IdentityServerConfig.GetApis())
                        .AddInMemoryClients(IdentityServerConfig.GetClients())
                        .AddInMemoryPersistedGrants()
                        .AddProfileService<ProfileService>()
                        .AddDeveloperSigningCredential();

            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();

            //Keep it for reference - from the reference project
            //services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            //    .AddIdentityServerAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme, x =>
            //   {
            //        x.Authority = "http://localhost:5000";
            //        x.ApiName = "oeuvreAPI";
            //        x.RequireHttpsMetadata = false;

            //   });

            services.AddAuthentication("Bearer")
                    .AddJwtBearer("Bearer", options =>
                    {
                        options.Authority = "http://localhost:5000";
                        options.Audience = "oeuvreAPI";

                        //options.ClaimsIssuer = "http://localhost:5000";

                        options.RequireHttpsMetadata = false;

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = false
                        };
                    });
        }

        private static void ConfigureLoggerForAPI()
        {
            string apiLogPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
                                    + "\\OeuvreLogs\\API\\API";

            loggerForApi = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] [{Module}] [{Context}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.RollingFile(new CompactJsonFormatter(), apiLogPath)
                .CreateLogger();

            loggerForApi = loggerForApi.ForContext("Module", "API");

            loggerForApi.Information("Logger configured");
        }

        private void InitializeModules(ILifetimeScope container)
        {
            var httpContextAccessor = container.Resolve<IHttpContextAccessor>();
            var executionContextAccessor = new ExecutionContextAccessor(httpContextAccessor);

            var emailsConfiguration = new EmailsConfiguration();
            configuration.Bind("EmailsConfiguration", emailsConfiguration);


            IdentityAccessStartup.Initialize(
                            configuration.GetConnectionString("DefaultConnection")
                            , executionContextAccessor
                            //,logger
                            ,emailsConfiguration
                            //,this._configuration["Security:TextEncryptionKey"]
                            ,null
                            );

            ContentCreationStartup.Initialize(
                            configuration.GetConnectionString("DefaultConnection")
                            , executionContextAccessor
                            //,logger
                            //,emailsConfiguration
                            //,this._configuration["Security:TextEncryptionKey"]
                            //,null
                            );

        }

    }
}
