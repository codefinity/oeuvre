using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Rules
{
    public class UserMustAcceptTermsAndConditions : IBusinessRule
    {
        private readonly bool termsAndConditionsAccepted;

        internal UserMustAcceptTermsAndConditions(bool termsAndConditionsAccepted)
        {
            this.termsAndConditionsAccepted = termsAndConditionsAccepted;
        }

        public bool IsBroken() => termsAndConditionsAccepted == false;

        public string Message => "User must accept terms and conditions";
    }
}
