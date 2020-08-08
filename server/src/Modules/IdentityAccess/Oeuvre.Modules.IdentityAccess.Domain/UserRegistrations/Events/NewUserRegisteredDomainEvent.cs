using System;
using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Events
{
    public class NewUserRegisteredDomainEvent : DomainEventBase
    {
        public UserRegistrationId UserRegistrationId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string EMailId { get; }

        public string MobileNumber { get; }

        public DateTime RegisterDate { get; }

        public NewUserRegisteredDomainEvent(UserRegistrationId userRegistrationId,
                                                string firstName, 
                                                string lastName,
                                                string mobileNumber,
                                                string email,  
                                                DateTime registerDate)
        {
            UserRegistrationId = userRegistrationId;
            FirstName = firstName;
            LastName = lastName;
            this.MobileNumber = mobileNumber;
            EMailId = email;

            RegisterDate = registerDate;
        }
    }
}