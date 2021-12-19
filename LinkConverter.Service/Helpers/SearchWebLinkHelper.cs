using LinkConverter.Domain.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkConverter.Service.Helpers
{
    internal class SearchWebLinkHelper
    {
        internal const string searchPattern = @"sr\?q=(?<Query>[^:\/\n=&]+)$";
        internal static string GenerateWebLink(string url)
        {
            var query = getQValue(url);
            //var query = System.Web.HttpUtility.UrlDecode(getQValue(url));

            return $"{Domain.Constant.UrlPrefixConsts.DeepLinkPrefix}Page=Search&Query={query}";
        }

        internal static bool IsSearch(string url)
        {
            return url.GetRegexMatch(SearchWebLinkHelper.searchPattern).Any();
        }
        private static string getQValue(string url)
        {
            var matchs = url.GetRegexMatch(searchPattern);
            if (matchs.Any())
            {
                return matchs.First().Groups["Query"].Value;
            }
            else return default;
        }
    }
}
