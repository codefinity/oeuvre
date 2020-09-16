using Domaina.CQRS;
using Domaina.CQRS.Command;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.DeactivateUser
{
    public class ActivateUserCommandHandler : ICommandHandler<ActivateUserCommand, Guid>
    {

        private readonly IUserRepository userRepository;

        public ActivateUserCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Guid> Handle(ActivateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(new UserId(request.UserId));

            user.Activate();

            await userRepository.UpdateAsync(user);

            return user.Id.Value;
        }

    }
}
