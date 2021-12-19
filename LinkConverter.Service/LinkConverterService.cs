using LinkConverter.Domain.Enums;
using LinkConverter.Domain.Exception;
using LinkConverter.Domain.Extensions;
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

            var pageType = GetPageType(url);
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
            }
            else throw new BadRequestException("Deep link convert fail.", "", ErrorType.Critical);

            return response;
        }

        public string DeepLinkToWebUrl(string deeplink)
        {
            //Convert logic

            var response = $"Response{deeplink}";
            ConverterHistoryRepository.AddHistory(deeplink, response, Domain.Enums.LinkConvertType.WebUrlToDeepLink);

            return response;
        }


        private PageType GetPageType(string url)
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
    }
}
