using Dapper;
using Domaina.CQRS;
using Domaina.CQRS.Query;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations
{
    public class UsersCounter : IUsersCounter
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public UsersCounter(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public int CountUsersWithLogin(string email)
        {
            var connection = sqlConnectionFactory.GetOpenConnection();

            const string sql = "SELECT " +
                               "COUNT(*) " +
                               "FROM [identityaccess].[v_Users] AS [User] " +
                               "WHERE [EMail] = @email";

            return connection.QuerySingle<int>(sql,
                new
                {
                    email
                });
        }
    }
}
