using Domaina.CQRS;
using Newtonsoft.Json;
using Domaina.CQRS;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.AddRole
{
    public class AddRoleToUserCommand : CommandBase<Guid>
    {
        [JsonConstructor]
        public AddRoleToUserCommand(Guid userId, string role)
        {
            this.UserId = userId;
            this.Role = role;
        }

        public Guid UserId { get; }
        public string Role { get; }
    }
}
