using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations
{
    public class MobileNumber : ValueObject
    {
        private readonly string countryCode;
        private readonly string number;

        public MobileNumber(string countryCode, string number)
        {
            this.countryCode = countryCode;
            this.number = number;
        }

        public string CountryCode { get { return countryCode; } }

        public string Number { get { return number; } }

    }
}
