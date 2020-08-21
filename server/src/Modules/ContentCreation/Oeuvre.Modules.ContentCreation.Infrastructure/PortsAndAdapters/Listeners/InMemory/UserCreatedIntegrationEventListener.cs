using Domaina.Infrastructure.EventBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.ContentCreation.Infrastructure.PortsAndAdapters.Listeners.InMemory
{
    public class UserCreatedIntegrationEventListener<T> : IIntegrationEventHandler<T>
                                                            where T : IntegrationEvent
    {
        public async Task Handle(T @event)
        {







            //using (var scope = UserAccessCompositionRoot.BeginLifetimeScope())
            //{
            //    using (var connection = scope.Resolve<ISqlConnectionFactory>().GetOpenConnection())
            //    {
            //        string type = @event.GetType().FullName;
            //        var data = JsonConvert.SerializeObject(@event, new JsonSerializerSettings
            //        {
            //            ContractResolver = new AllPropertiesContractResolver()
            //        });

            //        var sql = "INSERT INTO [users].[InboxMessages] (Id, OccurredOn, Type, Data) " +
            //                  "VALUES (@Id, @OccurredOn, @Type, @Data)";

            //        await connection.ExecuteScalarAsync(sql, new
            //        {
            //            @event.Id,
            //            @event.OccurredOn,
            //            type,
            //            data
            //        });
            //    }
            //}
        }
    }
}
