using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace LinkConverter.Tests
{
    [CollectionDefinition("Startup collection")]
    public class StartupFixtureCollection : ICollectionFixture<StartupFixture>
    {
    }
}
