using LinkConverter.Domain.Exception;
using LinkConverter.Domain.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkConverter.Service.Helpers
{
    internal class ProductDeepLinkHelper
    {
        private const string productPrefix = "https://www.trendyol.com/brand/name-p-";
        internal static string GenerateDeepLink(string deeplink)
        {
            var queryParameters = new List<string>();

            var productId = getProductId(deeplink);
            if (!productId.HasValue) throw new NotFoundExcepiton("Not found product"); //Ürün numarası zorunlu olduğu için

            var boutiqueId = getCampaignId(deeplink);
            if (boutiqueId.HasValue) queryParameters.Add($"boutiqueId={boutiqueId}");

            var merchantId = getMerchantId(deeplink);
            if (productId.HasValue) queryParameters.Add($"merchantId={merchantId}");

            return $"{productPrefix}{productId}?{string.Join('&', queryParameters)}";
        }

        #region Private

        private static int? getProductId(string deeplink)
        {
            var matchs = deeplink.GetRegexMatch(@"(?:ContentId=)(?<ContentValue>[\d^]+)");
            if (matchs.Any())
            {
                var value = matchs.First().Groups["ContentValue"].Value;
                return int.Parse(value);
            }
            else return default;
        }

        private static int? getCampaignId(string deeplink)
        {
            var matchs = deeplink.GetRegexMatch(@"(?:CampaignId=)(?<CampaignValue>[^&]+)");
            if (matchs.Any())
            {
                var value = matchs.First().Groups["CampaignValue"].Value;
                return !string.IsNullOrWhiteSpace(value) ? int.Parse(value) : default;
            }
            else return default;
        }

        private static int? getMerchantId(string deeplink)
        {
            var matchs = deeplink.GetRegexMatch(@"(?:MerchantId=)(?<MerchantValue>[^&]+)");
            if (matchs.Any())
            {
                var value = matchs.First().Groups["MerchantValue"].Value;
                return !string.IsNullOrWhiteSpace(value) ? int.Parse(value) : default;
            }
            else return default;
        }
        #endregion
    }
}
