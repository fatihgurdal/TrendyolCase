using System;
using System.Collections.Generic;
using System.Text;

namespace LinkConverter.Domain.Enums
{
    public enum LinkConvertType : byte
    {
        None = 0,
        WebUrlToDeepLink,
        DeepLinkToWebUrl
    }
}
