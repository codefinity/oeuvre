﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.IntegrationTests.SeedWork
{

    [CollectionDefinition("IdentityAcessIntegrationTestCollection",
        DisableParallelization =true)]
    public class IdentityAcessIntegrationTestCollection : ICollectionFixture<IdentityAcessIntegrationTestFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
