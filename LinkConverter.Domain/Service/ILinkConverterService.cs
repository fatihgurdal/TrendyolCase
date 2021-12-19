using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Domain.Service
{
    public interface ILinkConverterService
    {
        string WebUrlToDeepLink(string url);
        string DeepLinkToWebUrl(string deeplink);
    }
}
