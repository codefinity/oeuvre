using System;
using Newtonsoft.Json;
using Oeuvre.Modules.IdentityAccess.Application.Configuration.Commands;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.CreateUser
{
    public class CreateUserCommand : InternalCommandBase<Guid>
    {
        [JsonConstructor]
        public CreateUserCommand(Guid id, UserRegistrationId userRegistrationId): base(id)
        {
            UserRegistrationId = userRegistrationId;
        }

        public UserRegistrationId UserRegistrationId { get; }
    }
}