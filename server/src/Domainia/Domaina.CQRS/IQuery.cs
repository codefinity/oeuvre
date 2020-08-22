using System;
using MediatR;

namespace Domaina.CQRS
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}