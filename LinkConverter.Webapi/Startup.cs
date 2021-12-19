using FluentValidation.AspNetCore;

using LinkConverter.Application;
using LinkConverter.Domain.Validations;
using LinkConverter.Webapi.Filters;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkConverter.Webapi
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        private readonly IWebHostEnvironment Environment;
        private readonly ILogger logger;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment, ILogger logger)
        {
            Configuration = configuration;
            this.Environment = environment;
            this.logger = logger;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Link Converter",
                    Version = "v1",
                    Description = "Trendyol Link Converter Backend Applicant Test",
                    Contact = new OpenApiContact
                    {
                        Name = "Fatih GÜRDAL",
                        Email = "f.gurdal@hotmail.com.tr",
                        Url = new Uri("https://github.com/DevelopmentHiring/TrendyolCase-FatihGurdal")

                    },
                });
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(new ErrorFilter(this.Environment, logger));
                options.Filters.Add(new ValidationFilter());

                //Swagger ProducesResponseType
                options.Filters.Add(new ProducesResponseTypeAttribute((int)System.Net.HttpStatusCode.OK));
                options.Filters.Add(new ProducesResponseTypeAttribute(typeof(Models.ExceptionModel), (int)System.Net.HttpStatusCode.BadRequest));
                options.Filters.Add(new ProducesResponseTypeAttribute(typeof(Models.ExceptionModel), (int)System.Net.HttpStatusCode.NotFound));
                options.Filters.Add(new ProducesResponseTypeAttribute(typeof(Models.ExceptionModel), (int)System.Net.HttpStatusCode.InternalServerError));
            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>()); //Validation ModelState IsValid

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true; //Custom validation filter
            });

            //Dependency Injection 
            services.AddDbContextServices(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Link Converter");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }
}
