using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.Example.Collection.CollectionAsync
{

    [Collection("DemoCollectionAsync")]
    public class DemoCollectionAsyncOneTest: DemoTestBase
    {
        //https://xunit.net/docs/shared-context

        private DemoCollectionAsyncFixture fixture;

        public DemoCollectionAsyncOneTest(DemoCollectionAsyncFixture fixture)
        {
            this.fixture = fixture;

            Debug.WriteLine("DemoCollectionOneTest Constructor Ran");
        }


        [Fact]
        public async void Test_One()
        {



            Debug.WriteLine("DemoCollectionOneTest Test_One Ran");

            Assert.True(true);


        }

        [Fact]
        public async void Test_Two()
        {



            Debug.WriteLine("DemoCollectionOneTest Test_One Ran");

            Assert.True(true);



        }
    }
}
