using Domania.EventBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.IntegrationEvents
{
    public class UserCreatedIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; }
        public Guid TenantId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public UserCreatedIntegrationEvent(Guid id, 
                                                    DateTime occurredOn, 
                                                    Guid userId, 
                                                    Guid tenantId,
                                                    string firstName,
                                                    string lastName,
                                                    string email) : base(id, occurredOn)
        {
            UserId = userId;
            TenantId = tenantId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
