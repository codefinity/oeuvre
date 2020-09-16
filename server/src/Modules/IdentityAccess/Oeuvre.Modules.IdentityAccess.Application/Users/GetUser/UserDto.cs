using System;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.GetUser
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string CountryCode { get; set; }
        public string MobileNo { get; set; }
        public string EMail { get; set; }
        public bool IsActive { get; set; }

    }
}