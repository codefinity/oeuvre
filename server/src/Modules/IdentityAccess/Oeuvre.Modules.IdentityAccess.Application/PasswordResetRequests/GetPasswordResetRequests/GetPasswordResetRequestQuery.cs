using Domaina.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.GetPasswordResetRequests
{
    public class GetPasswordResetRequestQuery : QueryBase<PasswordResetRequestDto>
    {
        public GetPasswordResetRequestQuery(Guid passwordResetRequestId)
        {
            this.PasswordResetRequestId = passwordResetRequestId;
        }

        public Guid PasswordResetRequestId { get; }
    }
}
