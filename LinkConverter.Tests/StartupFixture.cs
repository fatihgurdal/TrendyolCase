using LinkConverter.Application;
using LinkConverter.Domain.Service;
using LinkConverter.Tests.Helper;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;

using System;
using System.IO;
using System.Linq;

namespace LinkConverter.Tests
{
    public class StartupFixture : IDisposable
    {
        public readonly ILinkConverterService linkConverterService;
        public StartupFixture()
        {
            LaunchSettingsHelper.SetEnvironments();

            var services = new ServiceCollection();

            var configuration = InitConfiguration();
            services.AddDbContextServices(configuration);

            var provider = services.BuildServiceProvider();
            linkConverterService = provider.GetService<ILinkConverterService>();
        }
        internal IConfiguration InitConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public void Dispose()
        {
            linkConverterService.Clear();
        }
    }
}
