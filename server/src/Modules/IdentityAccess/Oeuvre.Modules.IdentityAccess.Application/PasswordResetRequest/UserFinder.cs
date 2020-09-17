using Dapper;
using Domaina.CQRS.Query;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequest
{
    public class UserFinder : IUserFinder
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public UserFinder(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public int FindUser(string eMailId)
        {
            var connection = sqlConnectionFactory.GetOpenConnection();

            const string sql = "SELECT " +
                               "COUNT(*) " +
                               "FROM [identityaccess].[v_Users] AS [User] " +
                               "WHERE [EMail] = @eMailId";

            return connection.QuerySingle<int>(sql,
                new
                {
                    eMailId
                });
        }
    }
}
