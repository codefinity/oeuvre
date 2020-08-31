using Domaina.CQRS;
using Domaina.CQRS.Command;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.AddRole
{
    public class AddRoleToUserCommandHandler : ICommandHandler<AddRoleToUserCommand, Guid>
    {

        private readonly IUserRepository userRepository;

        public AddRoleToUserCommandHandler(
            IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Guid> Handle(AddRoleToUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(new UserId(request.UserId));

            user.AddRole(request.Role);

            await userRepository.UpdateAsync(user);

            return user.Id.Value;
        }

    }
}
