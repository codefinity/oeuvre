using System;
using Domaina.CQRS;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.CreateUser
{
    public class CreateUserCommand : InternalCommandBase<Guid>
    {
        public CreateUserCommand(Guid id, UserRegistrationId userRegistrationId): base(id)
        {
            UserRegistrationId = userRegistrationId;
        }

        public UserRegistrationId UserRegistrationId { get; }
    }
}