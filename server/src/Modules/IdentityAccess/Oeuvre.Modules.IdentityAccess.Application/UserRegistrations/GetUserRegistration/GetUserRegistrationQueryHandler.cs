﻿using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Domaina.CQRS;
using Domaina.CQRS.Query;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.GetUserRegistration
{
    internal class GetUserRegistrationQueryHandler : IQueryHandler<GetUserRegistrationQuery, UserRegistrationDto>
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public GetUserRegistrationQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<UserRegistrationDto> Handle(GetUserRegistrationQuery query, CancellationToken cancellationToken)
        {
            var connection = sqlConnectionFactory.GetOpenConnection();


            const string sql = "SELECT Id, TenantId, FirstName," +
                                        " LastName, CountryCode," +
                                        " MobileNo, EMail, Password," +
                                        " StatusCode, RegistrationDate," +
                                        " ConfirmedDate" +
                                        " FROM [identityaccess].[Registrations]" +
                                        " WHERE Id = @UserRegistrationId";

            return await connection.QuerySingleAsync<UserRegistrationDto>(sql,
                new
                {
                    query.UserRegistrationId
                });
        }
    }
}