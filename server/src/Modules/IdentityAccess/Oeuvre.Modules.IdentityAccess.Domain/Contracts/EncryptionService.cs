using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.Contracts
{
    public interface IEncryptionService
    {
        public string EncryptedValue(string plainTextValye);

    }
}
