using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Domaina.CQRS;
using Domaina.CQRS.Query;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.GetUser
{
    internal class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserDto>
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public GetUserQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var connection = sqlConnectionFactory.GetOpenConnection();

            const string sql = "SELECT " +
                               "[Id], " +
                               "[FirstName], " +
                               "[Lastname], " +
                               "[CountryCode], " +
                               "[MobileNo], " +
                               "[EMail], " +
                               "[Password], " +
                               "[IsActive] " +
                               "FROM [identityaccess].[v_Users] AS [User] " +
                               "WHERE Id = @UserId";
            
            return await connection.QuerySingleAsync<UserDto>(sql, new
            {
                request.UserId
            });
        }
    }
}