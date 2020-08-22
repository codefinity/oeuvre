using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.ContentCreation.Domain.Collaborators
{
    public interface ICollaboratorRepository
    {
        Task AddAsync(Collaborator member);

        Task<Collaborator> GetByIdAsync(CollaboratorId collaboratorId);
    }
}
