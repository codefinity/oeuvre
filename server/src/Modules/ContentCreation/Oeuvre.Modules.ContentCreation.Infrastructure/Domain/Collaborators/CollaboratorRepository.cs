using Microsoft.EntityFrameworkCore;
using Oeuvre.Modules.ContentCreation.Domain.Collaborators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.ContentCreation.Infrastructure.Domain.Collaborators
{
    public class CollaboratorRepository : ICollaboratorRepository
    {

        private readonly ContentCreationContext contentCreationContext;

        internal CollaboratorRepository(ContentCreationContext contentCreationContext)
        {
            this.contentCreationContext = contentCreationContext;
        }

        public async Task AddAsync(Collaborator collaborator)
        {
            await contentCreationContext.Collaborators.AddAsync(collaborator);

            try
            {
                await contentCreationContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public async Task<Collaborator> GetByIdAsync(CollaboratorId collaboratorId)
        {
            return await contentCreationContext.Collaborators.FirstOrDefaultAsync(x => x.Id == collaboratorId);
        }


    }
}
