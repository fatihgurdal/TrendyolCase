using LinkConverter.Domain.Repository;
using LinkConverter.Domain.Service;

using System;
using System.Collections.Generic;
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
            //Convert logic
            var response = $"Response{url}";
            ConverterHistoryRepository.AddHistory(url, response, Domain.Enums.LinkConvertType.WebUrlToDeepLink);

            return response;
        }

        public string DeepLinkToWebUrl(string deeplink)
        {
            //Convert logic

            var response = $"Response{deeplink}";
            ConverterHistoryRepository.AddHistory(deeplink, response, Domain.Enums.LinkConvertType.WebUrlToDeepLink);

            return response;
        }
    }
}
