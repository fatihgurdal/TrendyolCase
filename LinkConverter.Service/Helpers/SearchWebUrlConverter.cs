using LinkConverter.Domain.Extensions;
using LinkConverter.Domain.Helper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkConverter.Service.Helpers
{
    internal class SearchWebUrlConverter : Domain.Helper.LinkConverterHandler
    {
        private const string searchPattern = @"sr\?q=(?<Query>[^:\/\n=&]+)$";

        public SearchWebUrlConverter(LinkConverterHandler nextHandler) : base(nextHandler)
        {
        }

        public override string ConvertUrl(string url)
        {
            if (IsSearch(url))
            {
                return Convert(url);
            }
            else if (NextHandler != null)
            {
                return NextHandler.ConvertUrl(url);
            }
            else return default;
        }

        #region Private
        private string Convert(string url)
        {
            var query = GetQValue(url);
            //var query = System.Web.HttpUtility.UrlDecode(getQValue(url));

            return $"{Domain.Constant.UrlConsts.DeepLinkPrefix}Page=Search&Query={query}";
        }
        private bool IsSearch(string url)
        {
            return url.GetRegexMatch(searchPattern).Any();
        }
        private string GetQValue(string url)
        {
            return base.GetUrlValueWithRegex(url, searchPattern, "Query");
        }
        #endregion
    }
}
