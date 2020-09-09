using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Oeuvre.API.IntegrationTests
{
    public static class TestDBInitializationHelpers
    {
        private static readonly string integrationDbconnectionString 
            = "Server=DESKTOP-6DRE2VL;Database=oeuvre_integration_testing;Trusted_Connection=True;";

        public static void DropTablesAndViewsAndSchema()
        {
            using (var connection = new SqlConnection(integrationDbconnectionString))
            {
                var soultionPath = SoultionPath();

                string sqlScript = File.ReadAllText(
                    soultionPath + @"\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-drop-db-tables-and-views-and-schema.sql");

                connection.Execute(sqlScript);

            }

        }

        public static void CreateSchemaAndTablesAndViews()
        {
            using (var connection = new SqlConnection(integrationDbconnectionString))
            {
                var soultionPath = SoultionPath();

                string createSchemaScript = File.ReadAllText(
                    soultionPath + @"\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-create-schema.sql");
                connection.Execute(createSchemaScript);

                string createTablesScript = File.ReadAllText(
                    soultionPath + @"\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-create-db-tables.sql");
                connection.Execute(createTablesScript);

                string createViewsScript = File.ReadAllText(
                    soultionPath + @"\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-create-views.sql");
                connection.Execute(createViewsScript);

            }
        }

        public static void AddSeedData()
        {
            using (var connection = new SqlConnection(integrationDbconnectionString))
            {
                var soultionPath = SoultionPath();

                string createSchemaScript = File.ReadAllText(
                    soultionPath + @"\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-add-seed-data.sql");
                connection.Execute(createSchemaScript);

            }
        }

        public static void AddTestData()
        {
            using (var connection = new SqlConnection(integrationDbconnectionString))
            {
                var soultionPath = SoultionPath();

                string createSchemaScript = File.ReadAllText(
                    soultionPath + @"\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-add-test-data.sql");
                connection.Execute(createSchemaScript);

            }
        }


        private static string SoultionPath()
        {
            return Directory.GetParent(
                    Directory.GetParent(
                    Directory.GetParent(
                    Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).FullName
                    )
                    .FullName)
                    .FullName)
                    .FullName)
                .ToString();

        }

    }
}
