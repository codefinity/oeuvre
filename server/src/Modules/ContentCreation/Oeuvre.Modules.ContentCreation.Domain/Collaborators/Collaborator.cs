using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Domain.Collaborators
{
    public class Collaborator : Entity
    {
        private CollaboratorId id;

        private string name;

        private string email;

        public Collaborator(CollaboratorId id, string name, string email)
        {
            this.id = id;
            this.name = name;
            this.email = email;
        }


    }
}
