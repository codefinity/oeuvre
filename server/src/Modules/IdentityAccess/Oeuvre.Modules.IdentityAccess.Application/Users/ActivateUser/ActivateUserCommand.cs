using Domaina.CQRS;
using Domaina.CQRS.Command;
using Newtonsoft.Json;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.DeactivateUser
{
    public class ActivateUserCommand : CommandBase<Guid>
    {
        public ActivateUserCommand(Guid userId)
        {
            this.UserId = userId;
        }

        public Guid UserId { get; }
    }
}
