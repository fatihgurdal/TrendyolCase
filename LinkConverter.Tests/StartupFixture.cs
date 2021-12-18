using LinkConverter.Application;
using LinkConverter.Domain.Service;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LinkConverter.Tests
{
    public class StartupFixture
    {
        public readonly ITestService TestService;
        public StartupFixture()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            services.AddDbContextServices(configuration);

            var provider = services.BuildServiceProvider();
            TestService = provider.GetService<ITestService>();
        }
    }
}
