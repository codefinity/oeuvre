using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests
{
    public interface IUserFinder
    {
        (bool UserExists, bool Active) FindUser(string eMailId);
    }
}
