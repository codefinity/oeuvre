
using Domaina.CQRS;
using MediatR;

namespace Domaina.CQRS
{
    public interface IQueryHandler<in TQuery, TResult> : 
        IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {

    }
}