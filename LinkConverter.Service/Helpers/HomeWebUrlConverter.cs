using LinkConverter.Domain.Helper;

namespace LinkConverter.Service.Helpers
{
    internal class HomeWebUrlConverter : LinkConverterHandler
    {
        /// <summary>
        /// Araya farklı link türleri eklenebilmesi için son adımıda zincire dahil edildi.
        /// </summary>
        /// <param name="nextHandler"></param>
        public HomeWebUrlConverter(LinkConverterHandler nextHandler) : base(nextHandler)
        {
        }

        public override string ConvertUrl(string url)
        {
            return Domain.Constant.UrlConsts.WebDomain;
        }
    }
}
