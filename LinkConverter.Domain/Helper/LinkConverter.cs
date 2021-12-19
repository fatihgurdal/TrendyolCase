using LinkConverter.Domain.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkConverter.Domain.Helper
{
    public abstract class LinkConverterHandler
    {
        protected readonly LinkConverterHandler NextHandler;

        public LinkConverterHandler(LinkConverterHandler nextHandler)
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
