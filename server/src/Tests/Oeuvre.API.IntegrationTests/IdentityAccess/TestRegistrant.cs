using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.API.IntegrationTests.IdentityAccess
{
    public class TestRegistrant
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string CountryCode { get; set; }
        public string MobileNo { get; set; }
        public string EMail { get; set; }
        public string StatusCode { get; set; }
    }
}
