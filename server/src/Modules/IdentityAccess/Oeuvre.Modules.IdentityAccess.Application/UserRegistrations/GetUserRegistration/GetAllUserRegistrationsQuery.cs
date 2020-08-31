using Domaina.CQRS;
using Domaina.CQRS.Query;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.GetUserRegistration
{
    public class GetAllUserRegistrationQuery : IQuery<List<UserRegistrationDto>>
    {

    }
}
