using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations
{
    public interface IUserRegistrationConfirmationExpirationCalculator
    {
        DateTime Calculate(DateTime registrationDate);
    }
}
