using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Domain.Tenants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.Users.Events
{
    public class UserCreatedDomainEvent : DomainEventBase
    {
        public UserId UserId { get; }

        public TenantId TenantId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string EMail { get; }

        public Guid Id => Guid.NewGuid();   //throw new NotImplementedException();

        public DateTime OccurredOn => DateTime.Now; //throw new NotImplementedException();

        public UserCreatedDomainEvent(UserId userId,
                                                TenantId tenantId,
                                                string firstName,
                                                string lastName,
                                                string eMail)
        {
            UserId = userId;
            TenantId = tenantId;
            FirstName = firstName;
            LastName = lastName;
            EMail = eMail;

        }
    }
}
