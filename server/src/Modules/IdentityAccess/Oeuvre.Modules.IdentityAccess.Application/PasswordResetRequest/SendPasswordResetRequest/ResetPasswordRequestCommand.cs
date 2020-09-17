using Domaina.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequest.SendPasswordResetRequest
{
    public class ResetPasswordRequestCommand : CommandBase<Guid> 
    {

        public ResetPasswordRequestCommand(string eMailId)
        {
            this.EMailId = eMailId;
        }

        public string EMailId { get; set; }
    }
}
