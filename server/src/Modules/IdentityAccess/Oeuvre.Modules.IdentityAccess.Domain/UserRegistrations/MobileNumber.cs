using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations
{
    public class MobileNumber
    {
        private readonly string countryCode;
        private readonly string mobileNumber;

        public MobileNumber(string countryCode, string mobileNumber)
        {
            this.countryCode = countryCode;
            this.mobileNumber = mobileNumber;
        }

    }
}
