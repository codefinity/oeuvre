﻿using System;
using System.Collections.Generic;
using System.Text;
using Oeuvre.Modules.ContentCreation.Domain.Tenants;


namespace Oeuvre.Modules.ContentCreation.Domain.Collaborators

{
    public class Reviewer : Collaborator
    {
        public Reviewer(Guid id, Guid tenantId, string name, string email) : base(id, tenantId, name, email)
        {

        }

    }
}
