using MediatR;
using Oeuvre.Modules.ContentCreation.Application.Configuration.Command;
using Oeuvre.Modules.ContentCreation.Domain.Collaborators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.ContentCreation.Application.Collaborators
{
    public class CreateCollaboratorCommandHandler : ICommandHandler<CreateCollaboratorCommand>
    {
        private readonly ICollaboratorRepository collaboratorRepository;

        public CreateCollaboratorCommandHandler(ICollaboratorRepository collaboratorRepository)
        {
            this.collaboratorRepository = collaboratorRepository;
        }

        public async Task<Unit> Handle(CreateCollaboratorCommand request, 
                                            CancellationToken cancellationToken)
        {
            var collaborator = Collaborator.Create(request.Id,
                                                    request.TenantId,
                                                    request.Name,
                                                    request.EMail);

            try
            {

                await collaboratorRepository.AddAsync(collaborator);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }



            return Unit.Value;
        }

    }
}
