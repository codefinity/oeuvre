using System;
using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.Access
{
    public class Role: Entity
    {
        private string name;
        private string code;

        public Role(string name, string code)
        {
            this.name = name;
            this.code = code;
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
