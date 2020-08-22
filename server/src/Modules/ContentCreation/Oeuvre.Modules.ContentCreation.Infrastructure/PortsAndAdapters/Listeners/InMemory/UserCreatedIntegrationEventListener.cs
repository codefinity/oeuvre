using Autofac;
using Domania.EventBus;
using Oeuvre.Modules.ContentCreation.Application.Collaborators;
using Oeuvre.Modules.ContentCreation.Application.Contracts;
using Oeuvre.Modules.ContentCreation.Infrastructure.Configuration;
using Oeuvre.Modules.IdentityAccess.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace Oeuvre.Modules.ContentCreation.Infrastructure.PortsAndAdapters.Listeners.InMemory
{
    public class UserCreatedIntegrationEventListener<T> : IIntegrationEventHandler<UserCreatedIntegrationEvent>
    //where T : IntegrationEvent
    {
        public async Task Handle(UserCreatedIntegrationEvent @event)
        {


            var contentCreationModule = ContentCreationCompositionRoot.BeginLifetimeScope().Resolve<IContentCreationModule>();

            await contentCreationModule.ExecuteCommandAsync(new CreateCollaboratorCommand(
                                                @event.Id,
                                                @event.UserId,
                                                @event.TenantId,
                                                @event.FirstName + " " + @event.LastName,
                                                @event.Email));

        }
    }
}
