using System;
using System.Collections.Generic;
using System.Text;

using FluentValidation;

using LinkConverter.Domain.Models.Request;
using LinkConverter.Domain.Extensions;

namespace LinkConverter.Domain.Validations
{
    public class DeepLinkToWebUrlRequestValidator : AbstractValidator<DeepLinkToWebUrlRequest>
    {
        public DeepLinkToWebUrlRequestValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Request body cannot  be null. Please check request");

            When(x => x != null, () =>
            {
                RuleFor(x => x.Url).Must(x => x.IsUrl(true)).WithMessage("Invalid url");
                RuleFor(x => x.Url).Must(x => x.StartsWith("https://www.trendyol.com")).WithMessage("Invalid Trendyol url");
            });
        }
    }
}
