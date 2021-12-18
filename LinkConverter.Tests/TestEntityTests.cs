using LinkConverter.Domain.Service;

using System;
using System.Threading.Tasks;

using Xunit;
using Shouldly;

namespace LinkConverter.Tests
{
    [Collection("Startup collection")]
    public class TestEntityTests
    {
        private StartupFixture Fixture { get; }

        public TestEntityTests(StartupFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public async Task Add()
        {

            var id = Fixture.TestService.Add("fatih", 30);
            id.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task GetAll()
        {

            var texts = Fixture.TestService.GetAll();
            texts.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
