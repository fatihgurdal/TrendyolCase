using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System;
using System.IO;

namespace LinkConverter.Repository.Postgresql.Context
{
    internal class LinkConverterContextFactory : IDesignTimeDbContextFactory<LinkConverterContext>
    {
        private readonly IConfiguration Configuration;
        public LinkConverterContextFactory()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public LinkConverterContext CreateDbContext(params string[] args)
        {
            var connectionString = Configuration.GetConnectionString("LinkConverterPostgresqlConnection");
            var builder = new DbContextOptionsBuilder<LinkConverterContext>();
            builder.UseNpgsql(connectionString);
            return new LinkConverterContext(builder.Options);
        }

    }
}
