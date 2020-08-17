using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Oeuvre.Modules.IdentityAccess.Application.Authentication.Authenticate
{
    public class UserDto
    {

        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string CountryCode { get; set; }
        public string MobileNo { get; set; }
        public string EMail { get; set; }
        public List<Claim> Claims { get; set; }
        public bool IsActive { get; set; }





        //public Guid Id { get; set; }
        //public string Login { get; set; }

        //public bool IsActive { get; set; }

        //public string Name { get; set; }

        //public string Email { get; set; }

        //public List<Claim> Claims { get; set; }

        //public string Password { get; set; }
    }
}