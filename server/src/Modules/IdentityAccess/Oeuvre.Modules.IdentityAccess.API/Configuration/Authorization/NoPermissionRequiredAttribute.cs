using System;

namespace Oeuvre.Modules.IdentityAccess.API.Configuration.Authorization
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class NoPermissionRequiredAttribute : Attribute
    {

    }
}