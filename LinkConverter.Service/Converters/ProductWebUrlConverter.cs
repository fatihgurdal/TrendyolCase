
using LinkConverter.Domain.Exception;

using System.Collections.Generic;

namespace LinkConverter.Service.Converters
{
    internal class ProductWebUrlConverter : Domain.Abstract.LinkConverter
    {
        #region Consts
        private const string productPattern = @"(?:-p-)(?<ProductValue>[\d^]+)";
        private const string boutiquePattern = @"(?:boutiqueId=)(?<BoutiqueValue>[\d^]+)";
        private const string merchantPattern = @"(?:merchantId=)(?<MerchantValue>[\d^]+)";
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

            var productId = GetContentId(url);
            if (!string.IsNullOrEmpty(productId)) queryParameters.Add($"Page=Product&ContentId={productId}");

            var boutiqueId = GetBoutiqueId(url);
            if (!string.IsNullOrEmpty(boutiqueId)) queryParameters.Add($"CampaignId={boutiqueId}");

            var merchantId = GetMerchantId(url);
            if (!string.IsNullOrEmpty(merchantId)) queryParameters.Add($"MerchantId={merchantId}");

            return $"{Domain.Constant.UrlConsts.DeepLinkPrefix}{string.Join('&', queryParameters)}";
        }
        private bool IsProductDetail(string url)
        {
            return url.Contains("-p-") && !string.IsNullOrEmpty(GetContentId(url));
        }

        private string GetContentId(string url)
        {
            var contentId = base.GetUrlValueWithRegex(url, productPattern, "ProductValue");
            return contentId == "0" ? throw new BadRequestException("Content Id cannot be zero") : contentId;
        }

        private string GetBoutiqueId(string url)
        {
            var boutiqueId = base.GetUrlValueWithRegex(url, boutiquePattern, "BoutiqueValue");
            return boutiqueId == "0" ? throw new BadRequestException("Boutique Id cannot be zero") : boutiqueId;
        }

        private string GetMerchantId(string url)
        {
            var merchantId = base.GetUrlValueWithRegex(url, merchantPattern, "MerchantValue");
            return merchantId == "0" ? throw new BadRequestException("Terchant Id cannot be zero") : merchantId;
        }
        #endregion

    }
}
