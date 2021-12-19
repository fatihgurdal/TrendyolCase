
using System.Collections.Generic;

namespace LinkConverter.Service.Converters
{
    internal class ProductWebUrlConverter : Domain.Abstract.LinkConverter
    {
        #region Consts
        private const string productPattern = @"(?:-p-)(?<ProductValue>[\d^]+)";
        private const string boutiquePattern = @"(?:boutiqueId=)(?<BoutiqueValue>[\d^]+)";
        private const string merchanPattern = @"(?:merchantId=)(?<MerchantValue>[\d^]+)";
        #endregion

        public ProductWebUrlConverter(Domain.Abstract.LinkConverter nextHandler) : base(nextHandler)
        {
        }

        public override string ConvertUrl(string url)
        {
            if (IsProductDetail(url))
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
            var queryParameters = new List<string>();

            var productId = GetProductId(url);
            if (!string.IsNullOrEmpty(productId)) queryParameters.Add($"Page=Product&ContentId={productId}");

            var boutiqueId = GetBoutiqueId(url);
            if (!string.IsNullOrEmpty(boutiqueId)) queryParameters.Add($"CampaignId={boutiqueId}");

            var merchantId = GetMerchantId(url);
            if (!string.IsNullOrEmpty(merchantId)) queryParameters.Add($"MerchantId={merchantId}");

            return $"{Domain.Constant.UrlConsts.DeepLinkPrefix}{string.Join('&', queryParameters)}";
        }
        private bool IsProductDetail(string url)
        {
            return url.Contains("-p-") && !string.IsNullOrEmpty(GetProductId(url));
        }

        private string GetProductId(string url)
        {
            return base.GetUrlValueWithRegex(url, productPattern, "ProductValue");
        }

        private string GetBoutiqueId(string url)
        {
            return base.GetUrlValueWithRegex(url, boutiquePattern, "BoutiqueValue");
        }

        private string GetMerchantId(string url)
        {
            return base.GetUrlValueWithRegex(url, merchanPattern, "MerchantValue");
        }
        #endregion

    }
}
