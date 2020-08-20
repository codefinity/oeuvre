using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Domain.Collaborators
{
    public class Author: Collaborator
    {

        public Author(CollaboratorId id, string name, string email):base( id,  name,  email)
        {

        }

    }
}
