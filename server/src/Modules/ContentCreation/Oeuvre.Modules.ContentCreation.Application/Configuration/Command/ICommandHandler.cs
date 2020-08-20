using MediatR;
using Oeuvre.Modules.ContentCreation.Application.Contracts;

namespace Oeuvre.Modules.ContentCreation.Application.Configuration.Command
{
    public interface ICommandHandler<in TCommand> : 
        IRequestHandler<TCommand> where TCommand : ICommand
    {
        
    }

    public interface ICommandHandler<in TCommand, TResult> : 
        IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {

    }
}