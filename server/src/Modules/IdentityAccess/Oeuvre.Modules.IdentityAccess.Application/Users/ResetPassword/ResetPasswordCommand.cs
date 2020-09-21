using Domaina.CQRS.Command;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.ResetPassword
{
    public class ResetPasswordCommand : InternalCommandBase<Guid>
    {
        public ResetPasswordCommand(Guid id, string eMailId, string newPassword)
        : base(id)
        {
            EMailId = eMailId;
            NewPassword = newPassword;
        }

        internal string EMailId { get; }

        internal string NewPassword { get; }
    }
}
