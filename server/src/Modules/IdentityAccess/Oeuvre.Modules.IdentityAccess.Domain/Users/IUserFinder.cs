using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.Users
{
    public interface IUserFinder
    {
        int FindUser(string eMailId);
    }
}
