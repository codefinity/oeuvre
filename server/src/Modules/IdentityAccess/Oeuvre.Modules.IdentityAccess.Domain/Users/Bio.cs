using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.Users
{
    public class Bio : ValueObject
    {
        public Bio(string text)
        {
            this.BioText = text;
        }

        public string BioText { get; }

    }
}
