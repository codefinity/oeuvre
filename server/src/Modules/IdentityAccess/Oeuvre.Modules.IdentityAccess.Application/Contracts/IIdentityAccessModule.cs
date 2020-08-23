using Domaina.CQRS.Command;
using Domaina.CQRS.Query;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Application.Contracts
{
    public interface IIdentityAccessModule
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}