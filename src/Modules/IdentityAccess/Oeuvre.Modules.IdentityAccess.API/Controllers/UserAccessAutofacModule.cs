﻿using Autofac;
using Oeuvre.Modules.IdentityAccess.Application;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;

namespace Oeuvre.Modules.IdentityAccess.API.Controller
{
    public class UserAccessAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserAccessModule>()
                .As<IUserAccessModule>()
                .InstancePerLifetimeScope();
        }
    }
}