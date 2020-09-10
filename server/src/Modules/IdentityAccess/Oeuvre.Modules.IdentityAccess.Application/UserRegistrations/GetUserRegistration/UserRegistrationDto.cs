using System;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.GetUserRegistration
{
    public class UserRegistrationDto
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Password { get; }
        public string CountryCode { get; set; }
        public string MobileNo { get; }
        public string Email { get; }
    }
}