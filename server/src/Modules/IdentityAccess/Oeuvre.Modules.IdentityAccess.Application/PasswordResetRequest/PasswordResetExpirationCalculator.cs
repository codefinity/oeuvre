using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequest
{
    public class PasswordResetExpirationCalculator : IPasswordResetExpirationCalculator
    {
        private readonly string expirationTimePeriodInDays;

        public PasswordResetExpirationCalculator(
            //IConfiguration configuration
            )
        {
            expirationTimePeriodInDays = "2"; //configuration["IdentityAccess:DomainRules:ConfirmRegistrationExpirationPeriodInDays"];
        }

        public DateTime Calculate(DateTime passwordResetRequestDate)
        {
            return passwordResetRequestDate.AddDays(double.Parse(expirationTimePeriodInDays));
        }

    }
}
