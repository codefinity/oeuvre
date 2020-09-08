using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Oeuvre.API.IntegrationTests
{
    public static class TestDBHelpers
    {

        public static void DropTables()
        {

            using (var connection = new SqlConnection(
                "Server=DESKTOP-6DRE2VL;Database=oeuvre_integration_testing;Trusted_Connection=True;"))
            {

                var soultionPath = Directory.GetParent(
                    Directory.GetParent(
                    Directory.GetParent(
                    Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).FullName
                    )
                    .FullName)
                    .FullName)
                    .FullName);

                string sqlScript = File.ReadAllText(soultionPath + @"\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-drop-db-tables.sql");

                var affectedRows = connection.Execute(sqlScript);

                Console.WriteLine(affectedRows);

            }

        }

        public static void CreateTables()
        {
            using (var connection = new SqlConnection(
                "Server=DESKTOP-6DRE2VL;Database=oeuvre_integration_testing;Trusted_Connection=True;"))
            {

                var soultionPath = Directory.GetParent(
                    Directory.GetParent(
                    Directory.GetParent(
                    Directory.GetParent(
                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).FullName
                    )
                    .FullName)
                    .FullName)
                    .FullName);

                string sqlScript = File.ReadAllText(soultionPath + @"\Modules\IdentityAccess\DBScripts\oeuvre-identityaccess-create-db-tables.sql");

                var affectedRows = connection.Execute(sqlScript);

                Console.WriteLine(affectedRows);

            }

        }

    }
}
