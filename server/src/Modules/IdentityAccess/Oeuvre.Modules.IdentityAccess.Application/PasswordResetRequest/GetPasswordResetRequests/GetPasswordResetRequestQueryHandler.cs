using Dapper;
using Domaina.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequest.GetPasswordResetRequests
{
    public class GetPasswordResetRequestQueryHandler : IQueryHandler<GetPasswordResetRequestQuery, PasswordResetRequestDto>
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public GetPasswordResetRequestQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<PasswordResetRequestDto> Handle(GetPasswordResetRequestQuery query, CancellationToken cancellationToken)
        {
            var connection = sqlConnectionFactory.GetOpenConnection();


            const string sql = "SELECT [Id], " +
                                        "[UserId], " +
                                        "[RequestedOn], " +
                                        "[Status] " +
                                        "FROM [identityaccess].[PasswordResetRequests] " +
                                        "WHERE Id = @PasswordResetRequestId";

            return await connection.QuerySingleAsync<PasswordResetRequestDto>(sql,
                new
                {
                    query.PasswordResetRequestId
                });
        }


    }
}
