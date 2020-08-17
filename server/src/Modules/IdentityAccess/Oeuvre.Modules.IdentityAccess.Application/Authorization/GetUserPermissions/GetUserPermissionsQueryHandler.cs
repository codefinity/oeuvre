using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Domaina.Application.Data;
using Oeuvre.Modules.IdentityAccess.Application.Configuration.Queries;

namespace Oeuvre.Modules.IdentityAccess.Application.Authorization.GetUserPermissions
{
    internal class GetUserPermissionsQueryHandler : IQueryHandler<GetUserPermissionsQuery, List<UserPermissionDto>>
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public GetUserPermissionsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<List<UserPermissionDto>> Handle(GetUserPermissionsQuery request, CancellationToken cancellationToken)
        {
            var connection = sqlConnectionFactory.GetOpenConnection();

            const string sql = "SELECT " +
                               "[UserPermission].[PermissionCode] AS [Code] " +
                               "FROM [identityaccess].[v_UserPermissions] AS [UserPermission] " +
                               "WHERE [UserPermission].UserId = @UserId";
            var permissions = await connection.QueryAsync<UserPermissionDto>(sql, new {request.UserId});


            return permissions.AsList();
        }
    }
}