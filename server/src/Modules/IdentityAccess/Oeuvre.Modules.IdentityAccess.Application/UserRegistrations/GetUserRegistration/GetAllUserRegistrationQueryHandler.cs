using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Domaina.CQRS;
using Domaina.CQRS.Command;
using Domaina.CQRS.Query;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.GetUserRegistration
{
    internal class GetAllUserRegistrationQueryHandler : IQueryHandler<GetAllUserRegistrationQuery, 
                                                            List<UserRegistrationDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAllUserRegistrationQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<List<UserRegistrationDto>> Handle(GetAllUserRegistrationQuery query, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sql = "SELECT Id, TenantId, FirstName, LastName, CountryCode, MobileNo, EMail, Password, StatusCode, RegistrationDate, ConfirmedDate FROM [identityaccess].[Registrations]";
;
            var meetingGroups = await connection.QueryAsync<UserRegistrationDto>(sql);

            return meetingGroups.AsList();

        }

    }
}