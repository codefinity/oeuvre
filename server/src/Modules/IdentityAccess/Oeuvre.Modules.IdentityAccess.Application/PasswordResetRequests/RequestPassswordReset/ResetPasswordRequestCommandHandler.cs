using Domaina.CQRS.Command;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.RequestPassswordReset
{
    public class ResetPasswordRequestCommandHandler : ICommandHandler<ResetPasswordRequestCommand, Guid>
    {

        private readonly IPasswordResetRequestRepository passwordResetRequestRepository;
        private readonly IUserFinder userFinder;
        private readonly ILogger logger;

        public ResetPasswordRequestCommandHandler(IPasswordResetRequestRepository passwordResetRequestRepository
                                                    ,IUserFinder userFinder
                                                    ,ILogger logger)
        {
            this.passwordResetRequestRepository = passwordResetRequestRepository;
            this.userFinder = userFinder;
            this.logger = logger;
        }

        public async Task<Guid> Handle(ResetPasswordRequestCommand request, CancellationToken cancellationToken)
        {

            PasswordResetRequest resetRequest = PasswordResetRequest.CreatePasswordResetRequest(request.EMailId, userFinder);

            await passwordResetRequestRepository.AddAsync(resetRequest);

            return resetRequest.Id.Value;

        }
    }
}
