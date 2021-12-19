using LinkConverter.Domain.Exception;
using LinkConverter.Domain.Extensions;
using LinkConverter.Domain.Helper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkConverter.Service.Helpers
{
    internal class ProductDeepLinkConverter : LinkConverterHandler
    {
        private const string productPrefix = "https://www.trendyol.com/brand/name-p-";
        private const string productPattern = @"(?:ContentId=)(?<ContentValue>[\d^]+)";
        private const string campaignPattern = @"(?:CampaignId=)(?<CampaignValue>[\d^]+)";
        private const string merchantPattern = @"(?:MerchantId=)(?<MerchantValue>[\d^]+)";

        public ProductDeepLinkConverter(LinkConverterHandler nextHandler) : base(nextHandler)
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
        private string convert(string deeplink)
        {
            var queryParameters = new List<string>();

            var productId = getProductId(deeplink);
            if (string.IsNullOrEmpty(productId)) throw new NotFoundExcepiton("Not found product"); //Ürün numarası zorunlu olduğu için

            var boutiqueId = getCampaignId(deeplink);
            if (!string.IsNullOrEmpty(boutiqueId)) queryParameters.Add($"boutiqueId={boutiqueId}");

            var merchantId = getMerchantId(deeplink);
            if (!string.IsNullOrEmpty(merchantId)) queryParameters.Add($"merchantId={merchantId}");

            return $"{productPrefix}{productId}?{string.Join('&', queryParameters)}";
        }
        private bool IsProductDetail(string deeplink)
        {
            var pageName = base.GetUrlValueWithRegex(deeplink, Domain.Constant.UrlConsts.PagePattern, "PageValue");
            return pageName.Equals("Product", StringComparison.OrdinalIgnoreCase);
        }
        private string getProductId(string deeplink)
        {
            return base.GetUrlValueWithRegex(deeplink, productPattern, "ContentValue");
        }

        private string getCampaignId(string deeplink)
        {
            return base.GetUrlValueWithRegex(deeplink, campaignPattern, "CampaignValue");
        }

        private string getMerchantId(string deeplink)
        {
            return base.GetUrlValueWithRegex(deeplink, merchantPattern, "MerchantValue");
        }

        #endregion
    }
}
