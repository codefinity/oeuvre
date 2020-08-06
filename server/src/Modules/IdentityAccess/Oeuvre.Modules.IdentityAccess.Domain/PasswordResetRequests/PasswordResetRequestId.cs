using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests
{
    public class PasswordResetRequestId : TypedIdValueBase
    {
        public PasswordResetRequestId(Guid value) : base(value)
        {
        }
    }
}
