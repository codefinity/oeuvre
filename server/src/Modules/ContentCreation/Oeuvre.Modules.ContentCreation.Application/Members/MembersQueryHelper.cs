using System.Data;
using System.Threading.Tasks;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Members;
using Dapper;

namespace Oeuvre.Modules.ContentCreation.Application.Members
{
    public class MembersQueryHelper
    {
        public static async Task<MemberDto> GetMember(MemberId memberId, IDbConnection connection)
        {
            return await connection.QuerySingleAsync<MemberDto>(
                "SELECT " +
                                                                "[Member].[Id], " +
                                                                "[Member].[EMailId], " +
                                                                "[Member].[FirstName], " +
                                                                "[Member].[LastName] " +
                                                                "FROM [contentcreation].[v_Members] AS [Member] " +
                                                                "WHERE [Member].[Id] = @Id", new
                                                                {
                                                                    Id = memberId.Value
                                                                });
        }
    }
}