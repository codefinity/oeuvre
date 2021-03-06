﻿using System;
using Domaina.CQRS;
using Domaina.CQRS.Command;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.ConfirmUserRegistration
{
    public class ConfirmUserRegistrationCommand : CommandBase
    {
        public ConfirmUserRegistrationCommand(Guid userRegistrationId)
        {
            UserRegistrationId = userRegistrationId;
        }

        public Guid UserRegistrationId { get; }
    }
}