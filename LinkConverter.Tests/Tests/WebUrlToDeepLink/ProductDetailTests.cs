using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace LinkConverter.Tests.Tests.WebUrlToDeepLink
{
    [Collection("Startup collection")]
    public class ProductDetailTests
    {
        private StartupFixture Fixture { get; }

        public ProductDetailTests(StartupFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public async Task Add()
        {

            var id = Fixture.TestService.Add("fatih", 30);
            id.ShouldBeGreaterThan(0);
        }
    }
}
