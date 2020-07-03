using System;
namespace Oeuvre.Modules.IdentityAccess.Application.CQRS
{
    public interface ICommandHandler
    {

    }

    public interface ICommandHandler<in TCommand, TResult> 
    {

    }
}
