using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Rules
{
    public class PasswordRequestIdMustMatchRule : IBusinessRule
    {
        public string Message => throw new NotImplementedException();

        public bool IsBroken()
        {
            throw new NotImplementedException();
        }
    }
}
