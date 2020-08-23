
using Domaina.CQRS;
using Domaina.CQRS.Command;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;

namespace Oeuvre.Modules.IdentityAccess.Application.Authentication.Authenticate
{
    public class AuthenticateCommand  : CommandBase<AuthenticationResult>
    {
        public AuthenticateCommand(string eMail, string password)
        {
            EMail = eMail;
            Password = password;
        }

        public string EMail { get; }

        public string Password { get; }
    }
}