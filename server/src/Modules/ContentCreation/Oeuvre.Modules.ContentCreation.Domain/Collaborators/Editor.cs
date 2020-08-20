using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Domain.Collaborators
{
    public class Editor : Collaborator
    {

        public Editor(CollaboratorId id, string name, string email) : base(id, name, email)
        {

        }

    }
}
