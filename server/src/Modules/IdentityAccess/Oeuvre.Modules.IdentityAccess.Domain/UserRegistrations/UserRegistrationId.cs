﻿using System;
using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations
{
    public class UserRegistrationId : TypedIdValueBase
    {
        public UserRegistrationId(Guid value) : base(value)
        {
        }
    }
}