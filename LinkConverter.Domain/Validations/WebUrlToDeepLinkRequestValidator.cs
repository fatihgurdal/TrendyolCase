using FluentValidation;
using FluentValidation.Results;

using LinkConverter.Domain.Models.Request;
using LinkConverter.Domain.Extensions;

namespace LinkConverter.Domain.Validations
{
    public class WebUrlToDeepLinkRequestValidator : AbstractValidator<WebUrlToDeepLinkRequest>
    {
        public WebUrlToDeepLinkRequestValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Request body cannot  be null. Please check request");

            When(x => x != null, () =>
            {
                RuleFor(x => x.Url).Must(x => x.IsUrl(true)).WithMessage("Invalid url");
                RuleFor(x => x.Url).Must(x => x.StartsWith("https://www.trendyol.com")).WithMessage("Invalid Trendyol url");
            });
        }

        public override ValidationResult Validate(ValidationContext<WebUrlToDeepLinkRequest> context)
        {
            return base.Validate(context);
        }
    }
}
