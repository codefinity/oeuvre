using Domaina.Infrastructure.EventBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.IntegrationEvents
{
    public class NewUserRegisteredIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; }
        public Guid TenantId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string MobileNo { get; }
        public NewUserRegisteredIntegrationEvent(Guid id, 
                                                    DateTime occurredOn, 
                                                    Guid userId, 
                                                    Guid tenantId,
                                                    string firstName,
                                                    string lastName,
                                                    string email,
                                                    string mobileNo) : base(id, occurredOn)
        {
            UserId = userId;
            TenantId = tenantId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            MobileNo = mobileNo;
        }
    }
}
