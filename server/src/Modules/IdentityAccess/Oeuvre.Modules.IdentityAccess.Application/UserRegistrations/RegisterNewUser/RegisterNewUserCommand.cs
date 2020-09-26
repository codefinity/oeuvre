using Domaina.CQRS;
using Domaina.CQRS.Command;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using System;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser
{
    public class RegisterNewUserCommand : CommandBase<Guid>
    {
        public RegisterNewUserCommand(string tenantId,
                                        string firstName, 
                                        string lastName, 
                                        string password,
                                        string mobileNoCountryCode,
                                        string mobileNumber, 
                                        string email,
                                        bool termsAndConditionsAccepted)
        {
            TenantId = tenantId;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            MobileNoCountryCode = mobileNoCountryCode;
            MobileNumber = mobileNumber;
            Email = email;
            TermsAndConditionsAccepted = termsAndConditionsAccepted;
        }

        public string TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string MobileNoCountryCode { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public bool TermsAndConditionsAccepted { get; set; }

    }
}