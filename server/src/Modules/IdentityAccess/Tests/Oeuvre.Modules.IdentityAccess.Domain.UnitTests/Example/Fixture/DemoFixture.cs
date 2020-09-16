using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.Example.Fixture
{

    public class DemoFixture : IDisposable
    {
        public DemoFixture()
        {

            // ... initialize data in the test database ...
            //Runs before all the tests in DemoFixtureTest
            Debug.WriteLine("DemoFixtureTest Fixture Constructor Ran");
        }

        public void Dispose()
        {


            // ... clean up test data from the database ...
            //Runs after all the tests in DemoFixtureTest
            Debug.WriteLine("DemoFixtureTest Fixture Dispose Ran");
        }

    }
}