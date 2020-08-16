using System;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.GetUser
{
    public class UserDto
    {

        public string TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string MobileNoCountryCode { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }


        //public Guid Id { get; set; }

        //public string Name { get; set; }

        //public string Login { get; set; }

        //public string Email { get; set; }

        //public bool IsActive { get; set; }
    }
}