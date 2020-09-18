using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests
{
    public interface IPasswordResetExpirationCalculator
    {
        DateTime Calculate(DateTime registrationDate);

    }
}
