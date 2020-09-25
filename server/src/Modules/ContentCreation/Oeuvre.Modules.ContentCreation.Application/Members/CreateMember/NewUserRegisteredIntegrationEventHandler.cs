using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Oeuvre.Modules.ContentCreation.Application.Members.CreateMember
{
    //public class NewUserRegisteredIntegrationEventHandler : INotificationHandler<NewUserRegisteredIntegrationEvent>
    //{
    //    private readonly ICommandsScheduler _commandsScheduler;

    //    public NewUserRegisteredIntegrationEventHandler(ICommandsScheduler commandsScheduler)
    //    {
    //        _commandsScheduler = commandsScheduler;
    //    }

    //    public Task Handle(NewUserRegisteredIntegrationEvent notification, CancellationToken cancellationToken)
    //    {
    //        _commandsScheduler.EnqueueAsync(new
    //            CreateMemberCommand(
    //                Guid.NewGuid(),
    //                notification.UserId,
    //                notification.Login,
    //                notification.Email,
    //                notification.FirstName,
    //                notification.LastName,
    //                notification.Name));

    //        return Task.CompletedTask;
    //    }
    //}
}