using Domaina.CQRS.Command;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.InitiatePasswordReset
{
    public class InitiatePasswordResetCommandHandler : ICommandHandler<InitiatePasswordResetCommand, Guid>
    {
        private readonly IPasswordResetRequestRepository passwordResetRequestRepository;
        private readonly IPasswordResetExpirationCalculator calculator;
        private readonly ILogger logger;

        public InitiatePasswordResetCommandHandler(IPasswordResetRequestRepository passwordResetRequestRepository
                                                    , IPasswordResetExpirationCalculator calculator
                                                    , ILogger logger)
        {
            this.passwordResetRequestRepository = passwordResetRequestRepository;
            this.calculator = calculator;
            this.logger = logger;
        }

        public async Task<Guid> Handle(InitiatePasswordResetCommand request, CancellationToken cancellationToken)
        {
            PasswordResetRequest passwordResetRequest = await passwordResetRequestRepository.GetByIdAsync(new PasswordResetRequestId(request.PasswordResetRequestId));

            passwordResetRequest.InitiatePasswordReset(calculator);

            await passwordResetRequestRepository.AddAsync(passwordResetRequest);

            return passwordResetRequest.Id.Value;
        }
    }
}
