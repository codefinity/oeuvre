using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Domain.Tenants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.Users.Events
{
    public class UserActivated : DomainEventBase
    {
        public UserId UserId { get; }

        public TenantId TenantId { get; }

        public Guid Id => Guid.NewGuid();

        public DateTime OccurredOn => DateTime.Now;


        public UserActivated(UserId userId,
                                        TenantId tenantId)
        {
            UserId = userId;
            TenantId = tenantId;

        }
    }
}
