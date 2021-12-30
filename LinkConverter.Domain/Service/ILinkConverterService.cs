using LinkConverter.Domain.Models.Response;

using System.Collections.Generic;

namespace LinkConverter.Domain.Service
{
    public interface ILinkConverterService
    {
        string WebUrlToDeepLink(string url);
        string DeepLinkToWebUrl(string deeplink);
        IEnumerable<LinkConvertHistoryResponse> GetHistories();
        /// <summary>
        /// Geliştirme ortamında testler çalıştıktan sonra verilerin silinmesi için kullanılır.
        /// </summary>
        void Clear();
    }
}
