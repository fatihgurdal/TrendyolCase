using FluentValidation;

using LinkConverter.Domain.Models.Request;
using LinkConverter.Domain.Repository;
using LinkConverter.Domain.Service;
using LinkConverter.Domain.Validations;
using LinkConverter.Repository.EFPostgresql.Context;
using LinkConverter.Repository.EFPostgresql.Repositories;
using LinkConverter.Service;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LinkConverter.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("LinkConverterPostgresqlConnection");
            services.AddDbContext<LinkConverterContext>(x => x.UseNpgsql(connectionString));

            #region LinkConverter
            services.AddScoped<ILinkConverterService, LinkConverterService>();
            services.AddScoped<ILinkConverterHistoryRepository, LinkConverterHistoryRepository>();
            //Validation
            services.AddTransient<IValidator<DeepLinkToWebUrlRequest>, DeepLinkToWebUrlRequestValidator>();
            services.AddTransient<IValidator<WebUrlToDeepLinkRequest>, WebUrlToDeepLinkRequestValidator>();
            #endregion

            #region Migration
            new LinkConverterContextFactory().Migrate();
            #endregion

            return services;
        }
    }
}
