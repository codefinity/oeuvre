using Domaina.CQRS.Command;
using Oeuvre.Modules.ContentCreation.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(IContentCreationModule).Assembly;
    }
}
