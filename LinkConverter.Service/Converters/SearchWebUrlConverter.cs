using LinkConverter.Domain.Extensions;

using System.Linq;

namespace LinkConverter.Service.Converters
{
    internal class SearchWebUrlConverter : Domain.Abstract.LinkConverter
    {
        private const string searchPattern = @"[?&]q=(?<Query>[^&]+).*$";

        public SearchWebUrlConverter(Domain.Abstract.LinkConverter nextHandler) : base(nextHandler)
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
