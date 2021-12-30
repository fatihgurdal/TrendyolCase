using LinkConverter.Domain.Exception;
using LinkConverter.Webapi.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

using System;

namespace LinkConverter.Webapi.Filters
{
    public class ErrorFilter : ExceptionFilterAttribute
    {
        readonly IWebHostEnvironment env;

        public ErrorFilter(IWebHostEnvironment Env)
        {
            this.env = Env;
        }
        public override void OnException(ExceptionContext context)
        {
            ExceptionModel exceptionModel = new ExceptionModel()
            {
                TraceId = Guid.NewGuid()
            };
            if (context.Exception is BaseException ex)
            {
                exceptionModel.Message = ex.Message;
                exceptionModel.Detail = ex.Detail;
                exceptionModel.Type = ex.Type;

                if (context.Exception is NotFoundExcepiton) context.HttpContext.Response.StatusCode = 404;
                if (context.Exception is BadRequestException) context.HttpContext.Response.StatusCode = 400;
                //logger.LogError(ex.Message, ex.Detail);
            }
            else
            {

                exceptionModel.Message = context.Exception.Message;

                exceptionModel.Detail = env.IsDevelopment() ? context.Exception.ToString() : default;

                context.HttpContext.Response.StatusCode = 500;

                //TODO: En son ILogger inject edilecek
                //logger.LogError(context.Exception, "unhandled error");
            }

            context.Result = new ObjectResult(exceptionModel);
        }
    }
}
