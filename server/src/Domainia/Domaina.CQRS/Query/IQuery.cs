using System;
using MediatR;

namespace Domaina.CQRS.Query
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}