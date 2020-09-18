using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests
{
    public class PasswordRequestStatus : ValueObject
    {
        public static PasswordRequestStatus ResetPending => new PasswordRequestStatus(nameof(ResetPending));
        public static PasswordRequestStatus NewPasswordReveived => new PasswordRequestStatus(nameof(NewPasswordReveived));

        public string Value { get; }

        private PasswordRequestStatus(string value)
        {
            Value = value;
        }
    }
}
