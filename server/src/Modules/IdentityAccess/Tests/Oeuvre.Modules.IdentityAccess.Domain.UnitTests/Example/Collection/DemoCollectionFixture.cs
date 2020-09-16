using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.Example.Collection
{
    public class DemoCollectionFixture : IDisposable
    {
        public DemoCollectionFixture()
        {
            // ... initialize data in the test database ...
            //Runs before all the tests in DemoFixtureTest
            Debug.WriteLine("DemoCollectionFixture Constructor Ran");
        }

        public void Dispose()
        {
            // ... clean up test data from the database ...
            //Runs after all the tests in DemoFixtureTest
            Debug.WriteLine("DemoCollectionFixture Dispose Ran");
        }

    }
}