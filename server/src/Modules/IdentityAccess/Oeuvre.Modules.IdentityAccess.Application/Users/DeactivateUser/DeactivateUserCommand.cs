using Domaina.CQRS;
using Newtonsoft.Json;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.DeactivateUser
{
    public class DeactivateUserCommand : CommandBase<Guid>
    {
        [JsonConstructor]
        public DeactivateUserCommand(Guid userId)
        {
            this.UserId = userId;
        }

        public Guid UserId { get; }
    }
}
