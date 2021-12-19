using LinkConverter.Domain.Extensions;

using System.Linq;

namespace LinkConverter.Domain.Abstract
{
    public abstract class LinkConverter
    {
        protected readonly LinkConverter NextHandler;

        public LinkConverter(LinkConverter nextHandler)
        {
            this.NextHandler = nextHandler;
        }

        public abstract string ConvertUrl(string url);

        protected virtual string GetUrlValueWithRegex(string url, string pattern, string regexGroupName)
        {
            var matchs = url.GetRegexMatch(pattern);
            if (matchs.Any())
            {
                return matchs.First().Groups[regexGroupName].Value;
            }
            else return default;
        }
    }
}
