using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Domaina.CQRS.Command;
using Domaina.CQRS.Query;
using Oeuvre.Modules.IdentityAccess.Application.Authentication;
using Oeuvre.Modules.IdentityAccess.Application.Authentication.Authenticate;

using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Application.IdentityServer;

namespace Oeuvre.Modules.IdentityAccess.Application.Application.Authentication.Authenticate
{
    public class AuthenticateCommandHandler : ICommandHandler<AuthenticateCommand, AuthenticationResult>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public AuthenticateCommandHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<AuthenticationResult> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            //Later - This needs to come from the Read DB materialized Views

            const string sql = "SELECT " +
                               "[Id], " +
                               "[TenantId], " +
                               "[FirstName], " +
                               "[LastName], " +
                               "[CountryCode], " +
                               "[MobileNo], " +
                               "[EMail], " +
                               "[Password], " +
                               "[IsActive] " +
                               "FROM [identityaccess].[Users] AS [User] " +
                               "WHERE [EMail] = @EMail";



            var user = await connection.QuerySingleOrDefaultAsync<UserDto>(sql,
                                                                    new
                                                                    {
                                                                        request.EMail,
                                                                    });

            if (user == null)
            {
                return new AuthenticationResult("Incorrect login or password");
            }

            if (!user.IsActive)
            {
                return new AuthenticationResult("User is not active");
            }

            if (!PasswordManager.VerifyHashedPassword(user.Password, request.Password))
            {
                return new AuthenticationResult("Incorrect login or password");
            }


            user.Claims = new List<Claim>();
            user.Claims.Add(new Claim(CustomClaimTypes.Name, (user.FirstName + " " + user.LastName)));
            user.Claims.Add(new Claim(CustomClaimTypes.EMail, user.EMail));


            return new AuthenticationResult(user);
        }
    }
}