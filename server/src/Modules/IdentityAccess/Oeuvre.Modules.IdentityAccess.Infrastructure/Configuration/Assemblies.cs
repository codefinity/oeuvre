using Oeuvre.Modules.IdentityAccess.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
    }
}
