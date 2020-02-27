using System;
using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.Identity
{
    public class Role : Value<Role>
    {
        public string Name { get; }

        private Role(string name)
        {
            this.Name = name;
        }
    }
}
