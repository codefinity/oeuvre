using System;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.GetUserRegistration
{
    public class UserRegistrationDto
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string CountryCode { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string StatusCode { get; set; }
    }
}