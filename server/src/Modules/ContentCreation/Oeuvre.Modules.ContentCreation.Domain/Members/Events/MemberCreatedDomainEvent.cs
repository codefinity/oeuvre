using CompanyName.MyMeetings.Modules.Meetings.Domain.Members;
using Domania.Domain;

namespace Oeuvre.Modules.ContentCreation.Domain.Members.Events
{
    public class MemberCreatedDomainEvent : DomainEventBase
    {
        public MemberId MemberId { get; }

        public MemberCreatedDomainEvent(MemberId memberId)
        {
            MemberId = memberId;
        }
    }
}