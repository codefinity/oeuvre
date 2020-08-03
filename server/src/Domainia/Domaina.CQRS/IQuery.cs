using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domaina.CQRS
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }
}
