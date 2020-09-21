using Domaina.CQRS.Command;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.SendPasswordResetRequestEmail
{
    public class SendPasswordResetRequestEmailCommand : InternalCommandBase
    {
        public SendPasswordResetRequestEmailCommand(Guid id, PasswordResetRequestId passwordResetRequestId, string email)
                                : base(id)
        {
            PasswordResetRequestId = passwordResetRequestId;
            Email = email;
        }

        internal PasswordResetRequestId PasswordResetRequestId { get; }

        internal string Email { get; }
    }
}
