using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.Users
{
    public class MobileNumber : ValueObject
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
