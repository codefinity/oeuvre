using System;
using CompanyName.MyMeetings.Modules.Meetings.Domain.Members;
using Domania.Domain;
using Oeuvre.Modules.ContentCreation.Domain;
using Oeuvre.Modules.ContentCreation.Domain.Members.Events;
using Oeuvre.Modules.ContentCreation.Domain.Tenants;

namespace Oeuvre.Modules.ContentCreation.Domain.Members
{
    public class Member : Entity, IAggregateRoot
    {
        public MemberId Id { get; private set; }

        private TenantId tenantId;

        private string eMailId;

        private string firstName;

        private string lastName;

        private Member()
        {
            //Empty Constructor required for EF
        }

        public static Member Create(Guid id, Guid tenantId, string eMailId, string firstName, string lastName)
        {
            return new Member(id, tenantId, eMailId, firstName, lastName);
        }

        private Member(Guid id, Guid tenantId, string eMailId, string firstName, string lastName)
        {
            this.Id = new MemberId(id);
            this.tenantId = new TenantId(tenantId);
            this.eMailId = eMailId;
            this.firstName = firstName;
            this.lastName = lastName;

            this.AddDomainEvent(new MemberCreatedDomainEvent(this.Id));
        }
    }
}