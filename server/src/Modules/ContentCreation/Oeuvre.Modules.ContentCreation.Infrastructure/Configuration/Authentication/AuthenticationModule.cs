using Autofac;
using Oeuvre.Modules.ContentCreation.Application.Members;
using Oeuvre.Modules.ContentCreation.Domain.Domain.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Infrastructure.Configuration.Authentication
{
    internal class AuthenticationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MemberContext>()
                .As<IMemberContext>()
                .InstancePerLifetimeScope();
        }
    }
}
