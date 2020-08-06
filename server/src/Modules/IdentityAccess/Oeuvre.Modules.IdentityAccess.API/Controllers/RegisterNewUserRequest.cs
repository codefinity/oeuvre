namespace Oeuvre.Modules.IdentityAccess.API.Controller
{
    public class RegisterNewUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public string EMail { get; set; }

    }
}