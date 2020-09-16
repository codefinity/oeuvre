﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.Example.Collection.CollectionAsync
{

    [CollectionDefinition("DemoCollectionAsync")]
    public class DemoCollectionAsync : ICollectionFixture<DemoCollectionAsyncFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

}
