﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.Example.Collection.CollectionAsync
{
    [Collection("DemoCollectionAsync")]
    public class DemoCollectionAsyncTwoTest: DemoTestBase
    {
        //https://xunit.net/docs/shared-context
        private DemoCollectionAsyncFixture fixture;

        public DemoCollectionAsyncTwoTest(DemoCollectionAsyncFixture fixture)
        {
            this.fixture = fixture;

            Debug.WriteLine("DemoCollectionTwoTest Constructor Ran");
        }


        [Fact]
        public void Test_One()
        {



            Debug.WriteLine("DemoCollectionTwoTest Test_One Ran");

            Assert.True(true);
        }

        [Fact]
        public void Test_Two()
        {



            Debug.WriteLine("DemoCollectionTwoTest Test_One Ran");

            Assert.True(true);
        }
    }
}
