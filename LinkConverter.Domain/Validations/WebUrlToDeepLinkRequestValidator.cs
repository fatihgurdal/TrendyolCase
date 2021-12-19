using FluentValidation;
using FluentValidation.Results;

using LinkConverter.Domain.Models.Request;

using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Domain.Validations
{
    public class WebUrlToDeepLinkRequestValidator : AbstractValidator<WebUrlToDeepLinkRequest>
    {
        public WebUrlToDeepLinkRequestValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Request body cannot  be null. Please check request");

            When(x => x != null, () =>
            {
                RuleFor(x => x.Url).Must(x => x.StartsWith("ty://?")).WithMessage("Invalid Trendyol depp link");
            });
        }

        public override ValidationResult Validate(ValidationContext<WebUrlToDeepLinkRequest> context)
        {
            return base.Validate(context);
        }
    }
}
