using LinkConverter.Domain.Enums;
using LinkConverter.Domain.Exception;
using LinkConverter.Domain.Models.Dto;
using LinkConverter.Domain.Models.Response;
using LinkConverter.Domain.Repository;
using LinkConverter.Domain.Service;
using LinkConverter.Service.Converters;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

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
            var productWebUrlConverter = new ProductWebUrlConverter(
                                                new SearchWebUrlConverter(
                                                    new HomeWebUrlConverter(null)));

            var response = productWebUrlConverter.ConvertUrl(url);
            if (!string.IsNullOrWhiteSpace(response))
            {
                ConverterHistoryRepository.AddHistory(new AddHistoryDto(url, response, LinkConvertType.WebUrlToDeepLink));
                return response;
            }
            else throw new BadRequestException("Deep link convert fail.", "", ErrorType.Critical);
        }

        public string DeepLinkToWebUrl(string deeplink)
        {
            var productWebUrlConverter = new ProductDeepLinkConverter(
                                               new SearchDeepLinkConverter(
                                                   new HomeDeepLinkConverter(null)));

            var response = productWebUrlConverter.ConvertUrl(deeplink);

            if (!string.IsNullOrWhiteSpace(response))
            {
                ConverterHistoryRepository.AddHistory(new AddHistoryDto(deeplink, response, Domain.Enums.LinkConvertType.DeepLinkToWebUrl));
                return response;
            }
            else throw new BadRequestException("Deep link convert fail.", "", ErrorType.Critical);
        }

        public IEnumerable<LinkConvertHistoryResponse> GetHistories()
        {
            return ConverterHistoryRepository.Get(x => true).Select(x => new LinkConvertHistoryResponse(x));
        }

        public void Clear()
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "UnitTest")
            {
                ConverterHistoryRepository.Clear();

            }
        }
    }
}
