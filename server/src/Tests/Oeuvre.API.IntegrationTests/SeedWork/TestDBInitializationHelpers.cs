using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Oeuvre.API.IntegrationTests.SeedWork
{
    public static class TestDBInitializationHelpers
    {
        private static readonly string integrationDbconnectionString = TestConfigurationVariables.ConnectionString;

        public static void DropTablesAndViewsAndSchema()
        {
            using (var connection = new SqlConnection(integrationDbconnectionString))
            {
                var soultionPath = PathHelpers.SoultionPath();

                string sqlScript = File.ReadAllText(
                    soultionPath + @"\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-drop-db-tables-and-views-and-schema.sql");

                connection.Execute(sqlScript);

            }

        }

        public static void CreateSchemaAndTablesAndViews()
        {
            using (var connection = new SqlConnection(integrationDbconnectionString))
            {
                var soultionPath = PathHelpers.SoultionPath();

                string createSchemaScript = File.ReadAllText(
                    soultionPath + @"\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-create-schema.sql");
                connection.Execute(createSchemaScript);

                string createTablesScript = File.ReadAllText(
                    soultionPath + @"\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-create-db-tables.sql");
                connection.Execute(createTablesScript);

                //Split the view file and run create view statements separately.
                //Running entire script file is not working.
                //Also removed "GO" keyword because its a sqlcmd keyword.
                string createViewsScriptContent = File.ReadAllText(
                    soultionPath
                    + @"\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-create-views.sql")
                    .Replace("GO", "");

                string[] ceateViewScripts = createViewsScriptContent.Split("--Split--");

                foreach (string createViewsScript in ceateViewScripts)
                {
                    connection.Execute(createViewsScript);
                }

            }
        }

        public static void AddSeedData()
        {
            using (var connection = new SqlConnection(integrationDbconnectionString))
            {
                var soultionPath = PathHelpers.SoultionPath();

                string createSchemaScript = File.ReadAllText(
                    soultionPath + @"\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-add-seed-data.sql");
                connection.Execute(createSchemaScript);

            }
        }

        public static void AddTestData()
        {
            using (var connection = new SqlConnection(integrationDbconnectionString))
            {
                var soultionPath = PathHelpers.SoultionPath();

                string createSchemaScript = File.ReadAllText(
                    soultionPath + @"\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-add-test-data.sql");
                connection.Execute(createSchemaScript);

            }
        }

    }
}
