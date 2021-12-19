using LinkConverter.Domain.Enums;
using LinkConverter.Domain.Exception;
using LinkConverter.Domain.Extensions;
using LinkConverter.Domain.Models.Response;
using LinkConverter.Domain.Repository;
using LinkConverter.Domain.Service;
using LinkConverter.Service.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkConverter.Service
{
    public class LinkConverterService : ILinkConverterService
    {
        readonly ILinkConverterHistoryRepository ConverterHistoryRepository;

        public LinkConverterService(ILinkConverterHistoryRepository converterHistoryRepository)
        {
            ConverterHistoryRepository = converterHistoryRepository;
        }
        public string WebUrlToDeepLink(string url)
        {
            string response;

            var pageType = GetWebUrlPageType(url);
            switch (pageType)
            {
                case PageType.Product:
                    response = ProductWebLinkHelper.GenerateWebLink(url);
                    break;
                case PageType.Search:
                    response = SearchWebLinkHelper.GenerateWebLink(url);
                    break;
                case PageType.Home:
                    response = $"{Domain.Constant.UrlPrefixConsts.DeepLinkPrefix}Page=Home";
                    break;
                default:
                    response = default;
                    break;
            }

            if (!string.IsNullOrWhiteSpace(response))
            {
                ConverterHistoryRepository.AddHistory(url, response, Domain.Enums.LinkConvertType.WebUrlToDeepLink);
                return response;
            }
            else throw new BadRequestException("Deep link convert fail.", "", ErrorType.Critical);
        }

        public string DeepLinkToWebUrl(string deeplink)
        {
            string response;


            var pageType = GeDeepLinkPageType(deeplink);

            switch (pageType)
            {
                case PageType.Product:
                    response = ProductDeepLinkHelper.GenerateDeepLink(deeplink);
                    break;
                case PageType.Search:
                    response = SearchDeepLinkHelper.GenerateDeepLink(deeplink);
                    break;
                case PageType.Home:
                default:
                    response = Domain.Constant.UrlPrefixConsts.WebDomain;
                    break;
            }

            if (!string.IsNullOrWhiteSpace(response))
            {
                ConverterHistoryRepository.AddHistory(deeplink, response, Domain.Enums.LinkConvertType.DeepLinkToWebUrl);
                return response;
            }
            else throw new BadRequestException("Deep link convert fail.", "", ErrorType.Critical);

        }

        public IEnumerable<LinkConvertHistoryResponse> GetHistories()
        {
            return ConverterHistoryRepository.Get(x => true).Select(x => new LinkConvertHistoryResponse(x));
        }

        #region Private
        private PageType GetWebUrlPageType(string url)
        {
            if (ProductWebLinkHelper.IsProductDetail(url))
            {
                return PageType.Product;
            }
            else if (SearchWebLinkHelper.IsSearch(url))
            {
                return PageType.Search;
            }
            else return PageType.Home;
        }
        private PageType GeDeepLinkPageType(string deeplink)
        {
            var matchs = deeplink.GetRegexMatch(@"(?:Page=)(?<PageValue>[^&]+)");
            if (matchs.Any())
            {
                var pageName = matchs.First().Groups["Query"].Value;
                if (pageName.Equals("Product", StringComparison.OrdinalIgnoreCase)) return PageType.Product;
                else if (pageName.Equals("Search", StringComparison.OrdinalIgnoreCase)) return PageType.Search;
                else return PageType.Home;
            }
            else return PageType.Home;


        }
        #endregion
    }
}
