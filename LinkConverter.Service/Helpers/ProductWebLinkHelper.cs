using LinkConverter.Domain.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkConverter.Service.Helpers
{
    internal static class ProductWebLinkHelper
    {
        internal static string GenerateWebLink(string url)
        {
            var queryParameters = new List<string>();

            var productId = getProductId(url);
            if (productId.HasValue) queryParameters.Add($"Page=Product&ContentId={productId}");

            var boutiqueId = getBoutiqueId(url);
            if (boutiqueId.HasValue) queryParameters.Add($"CampaignId={boutiqueId}");

            var merchantId = getMerchantId(url);
            if (productId.HasValue) queryParameters.Add($"MerchantId={merchantId}");

            return $"{Domain.Constant.UrlPrefixConsts.DeepLinkPrefix}{string.Join('&', queryParameters)}";
        }

        internal static bool IsProductDetail(string url)
        {
            return url.Contains("-p-") && ProductWebLinkHelper.getProductId(url).HasValue;
        }

        #region Private
        private static int? getProductId(string url)
        {
            var matchs = url.GetRegexMatch(@"(?:-p-)(?<ProductValue>[\d^]+)");
            if (matchs.Any())
            {
                var value = matchs.First().Groups["ProductValue"].Value;
                return int.Parse(value);
            }
            else return default;
        }

        private static int? getBoutiqueId(string url)
        {
            var matchs = url.GetRegexMatch(@"(?:boutiqueId=)(?<BoutiqueValue>[\d^]+)");
            if (matchs.Any())
            {
                var value = matchs.First().Groups["BoutiqueValue"].Value;
                return !string.IsNullOrWhiteSpace(value) ? int.Parse(value) : default;
            }
            else return default;
        }

        private static int? getMerchantId(string url)
        {
            var matchs = url.GetRegexMatch(@"(?:merchantId=)(?<MerchantValue>[\d^]+)");
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
