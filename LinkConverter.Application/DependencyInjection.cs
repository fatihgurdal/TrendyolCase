﻿using LinkConverter.Domain.Repository;
using LinkConverter.Domain.Service;
using LinkConverter.Repository.Postgresql.Context;
using LinkConverter.Repository.Postgresql.Repositories;
using LinkConverter.Service;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("LinkConverterPostgresqlConnection");
            services.AddDbContext<LinkConverterContext>(x => x.UseNpgsql(connectionString));

            #region Test
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<ITestRepository, TestRepository>();
            #endregion

            #region LinkConverter
            services.AddScoped<ILinkConverterService, LinkConverterService>();
            #endregion

            #region Migration
            new LinkConverterContextFactory().Migrate();
            #endregion

            return services;
        }
    }
}
