using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.API.IntegrationTests.SeedWork
{
    public static class DBAccessHelpers
    {
        private static readonly string integrationDbconnectionString = TestConfigurationVariables.ConnectionString;

        public static async Task<T> GetData<T>(string query)
        {
            using (var connection = new SqlConnection(integrationDbconnectionString))
            {
                var data = await connection.QuerySingleAsync<T>(query);

                return data;
            }
        }
    }
}
