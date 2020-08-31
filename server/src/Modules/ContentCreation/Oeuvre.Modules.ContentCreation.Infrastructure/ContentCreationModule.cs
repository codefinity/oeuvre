using Autofac;
using Domaina.CQRS.Command;
using Domaina.CQRS.Query;
using MediatR;
using Oeuvre.Modules.ContentCreation.Application.Contracts;
using Oeuvre.Modules.ContentCreation.Infrastructure.Configuration;
using Oeuvre.Modules.ContentCreation.Infrastructure.Configuration.Processing;
using System.Threading.Tasks;

namespace Oeuvre.Modules.ContentCreation.Infrastructure
{
    public class ContentCreationModule : IContentCreationModule
    {
        public async Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command)
        {
            return await CommandsExecutor.Execute(command);
        }

        public async Task ExecuteCommandAsync(ICommand command)
        {
            await CommandsExecutor.Execute(command);
        }

        public async Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query)
        {
            using (var scope = ContentCreationCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();

                return await mediator.Send(query);
            }
        }
    }
}
