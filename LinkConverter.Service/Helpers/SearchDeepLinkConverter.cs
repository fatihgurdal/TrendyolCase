using LinkConverter.Domain.Extensions;
using LinkConverter.Domain.Helper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkConverter.Service.Helpers
{
    public class SearchDeepLinkConverter : LinkConverterHandler
    {
        //ty://?Page=Search&Query=%C3%BCt%C3%BC
        //https://www.trendyol.com/sr?q=%C3%BCt%C3%BC
        private const string searchPattern = @"Query=(?<QueryValue>[^:\/\n=&]+)$";

        public SearchDeepLinkConverter(LinkConverterHandler nextHandler) : base(nextHandler)
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
        private string Convert(string deeplink)
        {
            var query = GetQValue(deeplink);

            return $"{Domain.Constant.UrlConsts.WebDomain}/sr?q={query}";
        }
        private bool IsSearch(string deeplink)
        {
            var pageName = base.GetUrlValueWithRegex(deeplink, Domain.Constant.UrlConsts.PagePattern, "PageValue");
            return pageName.Equals("Search", StringComparison.OrdinalIgnoreCase);
        }
        private string GetQValue(string deeplink)
        {
            return base.GetUrlValueWithRegex(deeplink, searchPattern, "QueryValue");
        }
        #endregion

    }
}
