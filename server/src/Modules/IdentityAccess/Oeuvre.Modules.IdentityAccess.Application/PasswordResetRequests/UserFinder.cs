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

            const string sql = "SELECT " +
                               "COUNT(*) " +
                               "FROM [identityaccess].[v_Users] AS [User] " +
                               "WHERE [EMail] = @eMailId AND [IsActive] = 'true'";

            int result = connection.QuerySingle<int>(sql,
                new
                {
                    eMailId
                });

            bool exists = result == 1;

            bool active = result == 1;

            return (exists, active);

        }
    }
}
