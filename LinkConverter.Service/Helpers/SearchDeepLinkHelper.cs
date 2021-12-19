using LinkConverter.Domain.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkConverter.Service.Helpers
{
    internal class SearchDeepLinkHelper
    {
        //ty://?Page=Search&Query=%C3%BCt%C3%BC
        //https://www.trendyol.com/sr?q=%C3%BCt%C3%BC
        private const string searchPattern = @"Query=(?<QueryValue>[^:\/\n=&]+)$";
        internal static string GenerateDeepLink(string deeplink)
        {
            var query = getQValue(deeplink);

            return $"{Domain.Constant.UrlConsts.WebDomain}/sr?q={query}";
        }

        private static string getQValue(string deeplink)
        {
            var matchs = deeplink.GetRegexMatch(searchPattern);
            if (matchs.Any())
            {
                return matchs.First().Groups["QueryValue"].Value;
            }
            else return default;
        }
    }
}
