using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.IntegrationTests.SeedWork
{
    public static class PathHelpers
    {
        public static string SoultionPath()
        {
            return Directory.GetParent(
                    Directory.GetParent(
                    Directory.GetParent(
                    Directory.GetParent(
                    Directory.GetParent(
                    Directory.GetParent(

                    Directory.GetParent(
                        Directory.GetCurrentDirectory()).FullName
                    )
                    .FullName)
                    .FullName)
                    .FullName)
                    .FullName)
                    .FullName).ToString();

        }
    }
}
