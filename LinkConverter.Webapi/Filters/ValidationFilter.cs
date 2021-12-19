using LinkConverter.Domain.Enums;
using LinkConverter.Domain.Exception;

using Microsoft.AspNetCore.Mvc.Filters;

using System;
using System.Linq;

namespace LinkConverter.Webapi.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(e => e.ErrorMessage)).ToList();
                var errorTitle = "Fill in the required fields";
                var error = string.Join(Environment.NewLine, errors);
                throw new BadRequestException(errorTitle, error, ErrorType.Validation);
            }
            else
            {
                base.OnActionExecuting(context);
            }
        }
    }
}
