using System;
using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Domain.Tenants;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Events
{
    public class NewUserRegisteredDomainEvent : IDomainEvent
    {
        public UserRegistrationId UserRegistrationId { get; }

        public TenantId TenantId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string EMail { get; }

        public string MobileNumber { get; }

        public DateTime RegisterDate { get; }

        public Guid Id => Guid.NewGuid();   //throw new NotImplementedException();

        public DateTime OccurredOn => DateTime.Now; //throw new NotImplementedException();

        public NewUserRegisteredDomainEvent(UserRegistrationId userRegistrationId,
                                                TenantId tenantId,
                                                string firstName, 
                                                string lastName,
                                                string mobileNumber,
                                                string eMail,  
                                                DateTime registerDate)
        {
            UserRegistrationId = userRegistrationId;
            TenantId = tenantId;
            FirstName = firstName;
            LastName = lastName;
            MobileNumber = mobileNumber;
            EMail = eMail;

            RegisterDate = registerDate;
        }
    }
}