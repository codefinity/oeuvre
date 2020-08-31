using Domaina.CQRS;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(IIdentityAccessModule).Assembly;
    }
}
