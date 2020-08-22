using Domaina.CQRS;
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
                                        string email )
        {
            TenantId = tenantId;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            MobileNoCountryCode = mobileNoCountryCode;
            MobileNumber = mobileNumber;
            Email = email;
        }

        public string TenantId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Password { get; }
        public string MobileNoCountryCode { get; set; }
        public string MobileNumber { get; }
        public string Email { get; }

    }
}