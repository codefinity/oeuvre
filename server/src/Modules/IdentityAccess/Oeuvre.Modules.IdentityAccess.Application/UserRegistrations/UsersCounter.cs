using Dapper;
using Domaina.CQRS;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations
{
    public class UsersCounter : IUsersCounter
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public UsersCounter(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public int CountUsersWithLogin(string login)
        {
            //var connection = _sqlConnectionFactory.GetOpenConnection();

            //const string sql = "SELECT " +
            //                   "COUNT(*) " +
            //                   "FROM [users].[v_Users] AS [User]" +
            //                   "WHERE [User].[Login] = @Login";
            //return connection.QuerySingle<int>(sql,
            //    new
            //    {
            //        login
            //    });

            return 0;
        }
    }
}
