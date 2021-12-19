using LinkConverter.Application;
using LinkConverter.Domain.Service;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LinkConverter.Tests
{
    public class StartupFixture
    {
        public readonly ITestService TestService;
        public readonly ILinkConverterService linkConverterService;
        public StartupFixture()
        {
            var services = new ServiceCollection();

            var configuration = InitConfiguration();

            services.AddDbContextServices(configuration);

            var provider = services.BuildServiceProvider();
            TestService = provider.GetService<ITestService>();
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
    }
}
