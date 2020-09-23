using Domaina.CQRS.Command;
using Oeuvre.Modules.IdentityAccess.Application.Authentication;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.SendNewPassword
{
    public class SendNewPasswordCommandHandler : ICommandHandler<SendNewPasswordCommand, Guid>
    {
        private readonly IPasswordResetRequestRepository passwordResetRequestRepository;
        private readonly IPasswordResetExpirationCalculator calculator;
        private readonly IUserFinder finder;
        private readonly ILogger logger;

        public SendNewPasswordCommandHandler(IPasswordResetRequestRepository passwordResetRequestRepository
                                                    ,IPasswordResetExpirationCalculator calculator
                                                    ,IUserFinder finder
                                                    ,ILogger logger)
        {
            this.passwordResetRequestRepository = passwordResetRequestRepository;
            this.calculator = calculator;
            this.finder = finder;
            this.logger = logger;
        }

        public async Task<Guid> Handle(SendNewPasswordCommand request, CancellationToken cancellationToken)
        {
            PasswordResetRequest passwordResetRequest = await passwordResetRequestRepository.GetByIdAsync(new PasswordResetRequestId(request.PasswordResetRequestId));

            passwordResetRequest.SendNewPassword(request.NewPassword, calculator, finder);

            await passwordResetRequestRepository.AddAsync(passwordResetRequest);

            return passwordResetRequest.Id.Value;
        }
    }
}
