using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domaina.CQRS
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
        long Id { get; }
    }

    public interface ICommand : IRequest
    {
        long Id { get; }
    }
}
