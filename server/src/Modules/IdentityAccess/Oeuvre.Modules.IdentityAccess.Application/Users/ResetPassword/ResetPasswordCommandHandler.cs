using Domaina.CQRS.Command;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.ResetPassword
{
    internal class ResetPasswordCommandHandler : ICommandHandler<ResetPasswordCommand, Guid>
    {
        private readonly IUserRepository userRepository;

        public ResetPasswordCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Guid> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByEMailIdAsync(request.EMailId);

            user.ResetPassword(request.NewPassword);

            await userRepository.AddAsync(user);

            return user.Id.Value;
        }
    }
}
