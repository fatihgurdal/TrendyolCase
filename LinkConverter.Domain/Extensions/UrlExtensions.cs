using System;

namespace LinkConverter.Domain.Extensions
{
    public static class UrlExtensions
    {
        public static bool IsUrl(this string url, bool requiredHttps)
        {
            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && requiredHttps ? uriResult.Scheme == Uri.UriSchemeHttps : (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
