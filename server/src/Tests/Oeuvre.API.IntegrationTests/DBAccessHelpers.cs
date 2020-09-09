using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.API.IntegrationTests
{
    public static class DBAccessHelpers
    {
        private static readonly string integrationDbconnectionString
                = "Server=DESKTOP-6DRE2VL;Database=oeuvre_integration_testing;Trusted_Connection=True;";

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
