using LinkConverter.Domain.Helper;

using System.Collections.Generic;

namespace LinkConverter.Service.Helpers
{
    internal class ProductWebUrlConverter : LinkConverterHandler
    {
        #region Consts
        private const string productPattern = @"(?:-p-)(?<ProductValue>[\d^]+)";
        private const string boutiquePattern = @"(?:boutiqueId=)(?<BoutiqueValue>[\d^]+)";
        private const string merchanPattern = @"(?:merchantId=)(?<MerchantValue>[\d^]+)"; 
        #endregion

        public ProductWebUrlConverter(LinkConverterHandler nextHandler) : base(nextHandler)
        {
        }

        public override string ConvertUrl(string url)
        {
            if (IsProductDetail(url))
            {
                return convert(url);
            }
            else if (NextHandler != null)
            {
                return NextHandler.ConvertUrl(url);
            }
            else return default;
        }

        #region Private
        private string convert(string url)
        {
            var queryParameters = new List<string>();

            var productId = getProductId(url);
            if (!string.IsNullOrEmpty(productId)) queryParameters.Add($"Page=Product&ContentId={productId}");

            var boutiqueId = getBoutiqueId(url);
            if (!string.IsNullOrEmpty(boutiqueId)) queryParameters.Add($"CampaignId={boutiqueId}");

            var merchantId = getMerchantId(url);
            if (!string.IsNullOrEmpty(merchantId)) queryParameters.Add($"MerchantId={merchantId}");

            return $"{Domain.Constant.UrlConsts.DeepLinkPrefix}{string.Join('&', queryParameters)}";
        }
        private bool IsProductDetail(string url)
        {
            return url.Contains("-p-") && !string.IsNullOrEmpty(getProductId(url));
        }

        private string getProductId(string url)
        {
            return base.GetUrlValueWithRegex(url, productPattern, "ProductValue");
        }

        private string getBoutiqueId(string url)
        {
            return base.GetUrlValueWithRegex(url, boutiquePattern, "BoutiqueValue");
        }

        private string getMerchantId(string url)
        {
            return base.GetUrlValueWithRegex(url, merchanPattern, "MerchantValue");
        }
        #endregion

    }
}
