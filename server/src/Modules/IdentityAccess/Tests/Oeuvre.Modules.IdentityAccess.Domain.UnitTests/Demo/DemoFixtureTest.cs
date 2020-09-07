using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.Demo
{
    public class DemoFixtureTest : IClassFixture<DemoFixture>
    {
        //https://xunit.net/docs/shared-context

        private DemoFixture fixture;

        public DemoFixtureTest(DemoFixture fixture)
        {
            this.fixture = fixture;

            Debug.WriteLine("DemoTest Constructor Ran");
        }


        [Fact]
        public void Test_One()
        {



            Debug.WriteLine("DemoTwoTest Test_One Ran");

            Assert.True(true);
        }

        [Fact]
        public void Test_Two()
        {



            Debug.WriteLine("DemoTwoTest Test_One Ran");

            Assert.True(true);
        }

    }
}
