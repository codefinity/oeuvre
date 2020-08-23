
using Domaina.CQRS;
using MediatR;

namespace Domaina.CQRS.Query
{
    public interface IQueryHandler<in TQuery, TResult> : 
        IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {

    }
}