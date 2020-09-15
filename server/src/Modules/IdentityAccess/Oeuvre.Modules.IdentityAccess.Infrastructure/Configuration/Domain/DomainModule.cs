﻿using Autofac;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration.Domain
{
    internal class DomainModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UsersCounter>()
                            .As<IUsersCounter>()
                            .InstancePerLifetimeScope();

            builder.RegisterType<UserRegistrationConfirmationExpirationCalculator>()
                            .As<IUserRegistrationConfirmationExpirationCalculator>()
                            .InstancePerLifetimeScope();
        }
    }
}
