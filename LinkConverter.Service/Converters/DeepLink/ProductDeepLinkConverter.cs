﻿using LinkConverter.Domain.Exception;

using System;
using System.Collections.Generic;

namespace LinkConverter.Service.Converters
{
    internal class ProductDeepLinkConverter : Domain.Abstract.LinkConverter
    {
        private const string productPrefix = "https://www.trendyol.com/brand/name-p-";
        private const string productPattern = @"(?:ContentId=)(?<ContentValue>[\d^]+)";
        private const string campaignPattern = @"(?:CampaignId=)(?<CampaignValue>[\d^]+)";
        private const string merchantPattern = @"(?:MerchantId=)(?<MerchantValue>[\d^]+)";

        public ProductDeepLinkConverter(Domain.Abstract.LinkConverter nextHandler) : base(nextHandler)
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
        private string Convert(string deeplink)
        {
            var queryParameters = new List<string>();

            var productId = GetProductId(deeplink);
            if (string.IsNullOrEmpty(productId)) throw new NotFoundExcepiton("Not found product"); //Ürün numarası zorunlu olduğu için

            var boutiqueId = GetCampaignId(deeplink);
            if (!string.IsNullOrEmpty(boutiqueId)) queryParameters.Add($"boutiqueId={boutiqueId}");

            var merchantId = GetMerchantId(deeplink);
            if (!string.IsNullOrEmpty(merchantId)) queryParameters.Add($"merchantId={merchantId}");

            return $"{productPrefix}{productId}?{string.Join('&', queryParameters)}".TrimEnd('?');
        }
        private bool IsProductDetail(string deeplink)
        {
            var pageName = base.GetUrlValueWithRegex(deeplink, Domain.Constant.UrlConsts.PagePattern, "PageValue");
            return pageName.Equals("Product", StringComparison.OrdinalIgnoreCase);
        }
        private string GetProductId(string deeplink)
        {
            var contentId = base.GetUrlValueWithRegex(deeplink, productPattern, "ContentValue");
            return contentId == "0" ? throw new BadRequestException("Content Id cannot be zero") : contentId;
        }

        private string GetCampaignId(string deeplink)
        {
            var campaingId = base.GetUrlValueWithRegex(deeplink, campaignPattern, "CampaignValue");
            return campaingId == "0" ? throw new BadRequestException("Content Id cannot be zero") : campaingId;
        }

        private string GetMerchantId(string deeplink)
        {
            var merchantId = base.GetUrlValueWithRegex(deeplink, merchantPattern, "MerchantValue");
            return merchantId == "0" ? throw new BadRequestException("Content Id cannot be zero") : merchantId;
        }

        #endregion
    }
}
