using CompanyName.MyMeetings.Modules.Meetings.Domain.Members;
using Domaina.Application;
using Oeuvre.Modules.ContentCreation.Domain.Domain.Members;

namespace Oeuvre.Modules.ContentCreation.Application.Members
{
    public class MemberContext : IMemberContext
    {
        private readonly IExecutionContextAccessor executionContextAccessor;

        public MemberContext(IExecutionContextAccessor executionContextAccessor)
        {
            this.executionContextAccessor = executionContextAccessor;
        }

        public MemberId MemberId => new MemberId(executionContextAccessor.UserId);
    }
}