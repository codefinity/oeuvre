using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Oeuvre.Modules.IdentityAccess.Application.CQRS;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistration.RegisterNewUser;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure
{
    internal static class CommandsExecutor
    {
        internal static async Task Execute(ICommand command)
        {


            //var assemblyPath = "...";
            //var typeName = "...";

            //var assembly = Assembly.LoadFrom(assemblyPath);
            //var loggerType = assembly.GetType(typeName);

            var serviceProvider = new ServiceCollection()
                .AddTransient(typeof(ICommandHandler), typeof(RegisterNewUserCommandHandler))
                .BuildServiceProvider();

            ICommandHandler ch = serviceProvider.GetService<ICommandHandler>();

            //ch.

            //logger.Send(command);

            //using (var scope = UserAccessCompositionRoot.BeginLifetimeScope())
            //{
            //    var mediator = scope.Resolve<IMediator>();
            //    await mediator.Send(command);
            //}


        }

        //internal static async Task<TResult> Execute<TResult>(ICommand<TResult> command)
        //{
            //using (var scope = UserAccessCompositionRoot.BeginLifetimeScope())
            //{
            //    var mediator = scope.Resolve<IMediator>();
            //    return await mediator.Send(command);
            //}
        //}
    }
}
