using Dapper;
using Domaina.Application.Data;
using Newtonsoft.Json;
using Oeuvre.Modules.ContentCreation.Application.Configuration.Command;
using Oeuvre.Modules.ContentCreation.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.ContentCreation.Infrastructure.Configuration.Processing
{
    public class CommandsScheduler : ICommandsScheduler
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public CommandsScheduler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task EnqueueAsync(ICommand command)
        {

            await CommandsExecutor.Execute(command);

            //var connection = this._sqlConnectionFactory.GetOpenConnection();

            //const string sqlInsert = "INSERT INTO [users].[InternalCommands] ([Id], [EnqueueDate] , [Type], [Data]) VALUES " +
            //                         "(@Id, @EnqueueDate, @Type, @Data)";

            //await connection.ExecuteAsync(sqlInsert, new
            //{
            //    command.Id,
            //    EnqueueDate = DateTime.UtcNow,
            //    Type = command.GetType().FullName,
            //    Data = JsonConvert.SerializeObject(command, new JsonSerializerSettings
            //    {
            //        ContractResolver = new AllPropertiesContractResolver()
            //    })
            //});
        }

        public async Task EnqueueAsync<T>(ICommand<T> command)
        {
            await CommandsExecutor.Execute(command);

            //var connection = this._sqlConnectionFactory.GetOpenConnection();

            //const string sqlInsert = "INSERT INTO [users].[InternalCommands] ([Id], [EnqueueDate] , [Type], [Data]) VALUES " +
            //                         "(@Id, @EnqueueDate, @Type, @Data)";

            //await connection.ExecuteAsync(sqlInsert, new
            //{
            //    command.Id,
            //    EnqueueDate = DateTime.UtcNow,
            //    Type = command.GetType().FullName,
            //    Data = JsonConvert.SerializeObject(command, new JsonSerializerSettings
            //    {
            //        ContractResolver = new AllPropertiesContractResolver()
            //    })
            //});
        }
    }
}
