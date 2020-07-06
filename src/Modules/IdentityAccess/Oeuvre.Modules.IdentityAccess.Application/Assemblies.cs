using Domaina.CQRS;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Application
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
    }
}
