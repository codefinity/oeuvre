using Domaina.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.SendNewPassword
{
    public class SendNewPasswordCommand : CommandBase<Guid>
    {
        public SendNewPasswordCommand(Guid passwordResetRequestId, string newPassword)
        {
            PasswordResetRequestId = passwordResetRequestId;
            NewPassword = newPassword;
        }

        public Guid PasswordResetRequestId { get; set; }

        public string NewPassword { get; set; }
    }
}
