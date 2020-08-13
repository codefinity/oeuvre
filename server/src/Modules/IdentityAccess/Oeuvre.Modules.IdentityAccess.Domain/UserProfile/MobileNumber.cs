using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserProfile
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

        public string CountryCode { get { return countryCode; } }

        public string Number { get { return mobileNumber; } }

    }
}
