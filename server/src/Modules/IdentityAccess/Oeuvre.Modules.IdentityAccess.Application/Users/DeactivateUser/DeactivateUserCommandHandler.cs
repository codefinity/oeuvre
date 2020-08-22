using Domaina.CQRS;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.DeactivateUser
{
    public class DeactivateUserCommandHandler : ICommandHandler<DeactivateUserCommand, Guid>
    {

        private readonly IUserRepository userRepository;

        public DeactivateUserCommandHandler(
            IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Guid> Handle(DeactivateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByIdAsync(new UserId(request.UserId));

            user.Deactivate();

            await userRepository.AddAsync(user);

            return user.Id.Value;
        }

    }
}
