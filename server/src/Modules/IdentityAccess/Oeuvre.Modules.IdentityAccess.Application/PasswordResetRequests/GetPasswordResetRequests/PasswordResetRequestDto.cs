using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.GetPasswordResetRequests
{
    public class PasswordResetRequestDto
    {
        public Guid Id { get; set; }

        public string EMail  { get; set; }

        public DateTime RequestedOn { get; set; }

        public string Status { get; set; }

    }
}
