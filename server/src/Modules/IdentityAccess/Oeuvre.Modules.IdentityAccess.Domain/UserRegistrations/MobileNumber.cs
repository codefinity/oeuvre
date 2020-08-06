using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations
{
    public class MobileNumber
    {
        private string countryCode;
        private string mobileNumber;

        public MobileNumber(string countryCode, string mobileNumber)
        {
            this.countryCode = countryCode;
            this.mobileNumber = mobileNumber;

        }

    }
}
