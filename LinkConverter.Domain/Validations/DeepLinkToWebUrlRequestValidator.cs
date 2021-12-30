using FluentValidation;

using LinkConverter.Domain.Models.Request;

namespace LinkConverter.Domain.Validations
{
    public class DeepLinkToWebUrlRequestValidator : AbstractValidator<DeepLinkToWebUrlRequest>
    {
        public DeepLinkToWebUrlRequestValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Request body cannot  be null. Please check request");

            When(x => x != null, () =>
            {
                RuleFor(x => x.Url).Must(x => x.StartsWith(Constant.UrlConsts.DeepLinkPrefix)).WithMessage("Invalid Trendyol depp link");
            });
        }
    }
}
