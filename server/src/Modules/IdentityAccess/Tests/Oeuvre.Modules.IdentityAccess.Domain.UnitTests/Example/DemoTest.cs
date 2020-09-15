using Oeuvre.Modules.IdentityAccess.Domain.UnitTests.SeedWork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.Example
{
    public class DemoTest : TestBase, IDisposable
    {
        //https://xunit.net/docs/shared-context
        public DemoTest()
        {
            //Runs before every Test Case / Fact
            Debug.WriteLine("DemoTest Constructor Ran");
        }
        public void Dispose()
        {
            //Runs after every Test Case / Fact
            Debug.WriteLine("DemoTest Dispose Ran");
        }

        [Fact]
        public void Test_One()
        {



            Debug.WriteLine("DemoTest Test_One Ran");

            Assert.True(true);
        }

        [Fact]
        public void Test_Two()
        {



            Debug.WriteLine("DemoTest Test_One Ran");

            Assert.True(true);
        }
    }
}
