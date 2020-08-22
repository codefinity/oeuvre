using System;
using MediatR;

namespace Domaina.CQRS
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }

    public interface ICommand: IRequest
    {
        Guid Id { get; }
    }
}