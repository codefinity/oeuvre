using System;
namespace Oeuvre.Modules.IdentityAccess.Application.CQRS
{

    public interface IQuery<out TResult>
    {
        Guid Id { get; }
    }

}
