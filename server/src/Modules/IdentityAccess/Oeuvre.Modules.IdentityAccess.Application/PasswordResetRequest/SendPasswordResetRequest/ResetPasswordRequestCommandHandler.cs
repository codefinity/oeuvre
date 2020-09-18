using Domaina.CQRS.Command;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequest.SendPasswordResetRequest
{
    public class ResetPasswordRequestCommandHandler : ICommandHandler<ResetPasswordRequestCommand, Guid>
    {

        private readonly IPasswordResetRequestRepository passwordResetRequestRepository;
        private readonly IUserRepository userRepository;
        private readonly ILogger logger;

        public ResetPasswordRequestCommandHandler(IPasswordResetRequestRepository passwordResetRequestRepository
                                        ,IUserRepository userRepository
                                        ,ILogger logger)
        {
            this.passwordResetRequestRepository = passwordResetRequestRepository;
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public async Task<Guid> Handle(ResetPasswordRequestCommand request, CancellationToken cancellationToken)
        {
            //var user = await userRepository.GetByEMailIdAsync(request.EMailId);

            //var resetPasswordRequest = user.CreateRequestPasswordReset();

            //await passwordResetRequestRepository.AddAsync(resetPasswordRequest);

            //return resetPasswordRequest.Id.Value;

            return new Guid();
        }
    }
}
