using Dapper;
using Domaina.CQRS.Query;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests
{
    public class UserFinder : IUserFinder
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public UserFinder(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public (bool UserExists, bool Active) FindUser(string eMailId)
        {
            var connection = sqlConnectionFactory.GetOpenConnection();

            const string sqlUserExists = "SELECT " +
                               "COUNT(*) " +
                               "FROM [identityaccess].[v_Users] AS [User] " +
                               "WHERE [EMail] = @eMailId";

            int resultUserExists = connection.QuerySingle<int>(sqlUserExists,
                new
                {
                    eMailId
                });


            const string sqlUserActive = "SELECT " +
                   "COUNT(*) " +
                   "FROM [identityaccess].[v_Users] AS [User] " +
                   "WHERE [EMail] = @eMailId AND [IsActive] = 'true'";

            int resultUserActive = connection.QuerySingle<int>(sqlUserActive,
                new
                {
                    eMailId
                });

            bool exists = resultUserExists == 1;

            bool active = resultUserActive == 1;

            return (exists, active);

        }
    }
}
