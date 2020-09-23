using Domaina.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.InitiatePasswordReset
{
   public class InitiatePasswordResetCommand : CommandBase<Guid>
    {
        public InitiatePasswordResetCommand(Guid passwordResetRequestId)
        {
            PasswordResetRequestId = passwordResetRequestId;
        }

        public Guid PasswordResetRequestId { get; set; }
    }
}
