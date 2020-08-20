using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Domain.Collaborators
{
    public class Reviewer : Collaborator
    {
        public Reviewer(CollaboratorId id, string name, string email) : base(id, name, email)
        {

        }

    }
}
