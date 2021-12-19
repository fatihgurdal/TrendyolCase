using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Domain.Constant
{
    public class UrlConsts
    {
        public const string DeepLinkPrefix = "ty://?";
        public const string WebDomain = "https://www.trendyol.com";
        public const string PagePattern = @"(?:Page=)(?<PageValue>[^&]+)";
    }
}
