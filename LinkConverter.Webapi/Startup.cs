using FluentValidation.AspNetCore;

using LinkConverter.Application;
using LinkConverter.Webapi.Filters;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using System;

namespace LinkConverter.Webapi
{
    public class Startup
    {
        private readonly IWebHostEnvironment Environment;
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            this.Environment = environment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
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
                options.Filters.Add(new ErrorFilter(this.Environment));
                options.Filters.Add(new ValidationFilter());

                //Swagger ProducesResponseType
                options.Filters.Add(new ProducesResponseTypeAttribute((int)System.Net.HttpStatusCode.OK));
                //Custom Error Response
                options.Filters.Add(new ProducesResponseTypeAttribute(typeof(Models.ExceptionModel), (int)System.Net.HttpStatusCode.BadRequest));
                options.Filters.Add(new ProducesResponseTypeAttribute(typeof(Models.ExceptionModel), (int)System.Net.HttpStatusCode.NotFound));
                options.Filters.Add(new ProducesResponseTypeAttribute(typeof(Models.ExceptionModel), (int)System.Net.HttpStatusCode.InternalServerError));
            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>()); //Validation ModelState IsValid;

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true; //Custom validation filter
            });

            //Dependency Injection 
            services.AddDbContextServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (!env.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Link Converter");
                    c.RoutePrefix = string.Empty;
                });
            }

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
