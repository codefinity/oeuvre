using System;
using Microsoft.AspNetCore.Authorization;

namespace Domania.Security.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public static string HasPermissionPolicyName = "HasPermission";
        public string Name { get; }

        public HasPermissionAttribute(string name) : base(HasPermissionPolicyName)
        {
            Name = name;
        }
    }
}