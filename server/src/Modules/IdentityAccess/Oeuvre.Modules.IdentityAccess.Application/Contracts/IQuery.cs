using System;
using MediatR;

namespace Oeuvre.Modules.IdentityAccess.Application.Contracts
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }
}