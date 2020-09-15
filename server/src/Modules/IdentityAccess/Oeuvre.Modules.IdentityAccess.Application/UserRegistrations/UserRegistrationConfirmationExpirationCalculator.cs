using Microsoft.Extensions.Configuration;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations
{
    public class UserRegistrationConfirmationExpirationCalculator : IUserRegistrationConfirmationExpirationCalculator
    {
        private readonly string expirationTimePeriodInDays;

        public UserRegistrationConfirmationExpirationCalculator(
            //IConfiguration configuration
            )
        {
            expirationTimePeriodInDays = "2"; //configuration["IdentityAccess:DomainRules:ConfirmRegistrationExpirationPeriodInDays"];
        }

        public DateTime Calculate(DateTime registrationDate)
        {
            return registrationDate.AddDays(double.Parse(expirationTimePeriodInDays));
        }
    }
}
