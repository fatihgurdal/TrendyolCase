using Xunit;

namespace LinkConverter.Tests
{
    [CollectionDefinition("Startup collection")]
    public class StartupFixtureCollection : ICollectionFixture<StartupFixture>
    {
    }
}
