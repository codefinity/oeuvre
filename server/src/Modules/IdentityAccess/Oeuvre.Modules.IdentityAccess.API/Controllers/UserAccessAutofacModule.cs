using Autofac;
using Oeuvre.Modules.IdentityAccess.Application;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Infrastructure;

namespace Oeuvre.Modules.IdentityAccess.API.Controller
{
    public class IdentityAccessAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IdentityAccessModule>()
                .As<IIdentityAccessModule>()
                .InstancePerLifetimeScope();
        }
    }
}